﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_05
{
    public partial class Form1 : Form
    {
        List<List<Point>> Polygons;
        List<Point> LastPolygon;
        List<Edge>[] y_group;
        ListOfActiveEdges ActiveEdges;

        // Координаты прямоугольной оболочки
        Point min_coord;
        Point max_coord;

        Bitmap saved_picture;
        Graphics g;
        Graphics g_move;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            
            y_group = new List<Edge>[canvasBase.Height];
            for (int i = 0; i < y_group.Length; i++)
                y_group[i] = new List<Edge>();

            ActiveEdges = new ListOfActiveEdges(canvasBase.Width);
            
            Polygons = new List<List<Point>>();
            Polygons.Add(new List<Point>());
            LastPolygon = Polygons[Polygons.Count - 1];

            min_coord = new Point(canvasBase.Width, canvasBase.Height);
            max_coord = new Point(0, 0);

            saved_picture = new Bitmap(canvasBase.Width, canvasBase.Height);
            g = Graphics.FromImage(saved_picture);
            g_move = canvasBase.CreateGraphics();
            canvasBase.Image = saved_picture;
            pen = new Pen(Color.Black, 1);

        }
        /*
        // Рисует все сохраненные точки
        private void DrawAllLines()
        {
            int i;
            for (i = 0; i < Polygons.Count() - 1; i++)
            {
                if (Polygons[i].Count > 1)
                {
                    g.DrawLines(pen, Polygons[i].ToArray());
                    g.DrawLine(pen, Polygons[i][0], Polygons[i][Polygons[i].Count - 1]);
                }
            }
            // последний многоугольник
            if (Polygons[i].Count > 1)
            {
                g.DrawLines(pen, Polygons[i].ToArray());
            }
        }*/

        private void DrawEdgeStatic(bool last_edge = false)
        {
            if (LastPolygon.Count >= 2)
            {
                Point a = LastPolygon[LastPolygon.Count - 1];
                Point b;
                if (!last_edge)
                    b = LastPolygon[LastPolygon.Count - 2];
                else
                    b = LastPolygon[0];

                g.DrawLine(pen, a, b);
            }
        }

        // Рисует линии к мыши из последней точки    
        private void DrawCurrentEdge()
        {
            if (LastPolygon.Count > 0)
            {
                Point a = LastPolygon[LastPolygon.Count - 1];
                Point b = canvasBase.PointToClient(MousePosition);

                if (ModifierKeys == Keys.Control)
                    b.Y = a.Y;

                g_move.DrawLine(pen, a, b);
            }
        }

        // Перемещение мыши внутри холста
        private void canvasBase_MouseMove(object sender, MouseEventArgs e)
        {
            labelLocation.Text = canvasBase.PointToClient(MousePosition).ToString();
            canvasBase.Refresh(); // Убирает g_move с холста
            DrawCurrentEdge();
        }

        // Нажатие на холст
        private void canvasBase_Click(object sender, EventArgs e)
        {
            Point mousePos = canvasBase.PointToClient(MousePosition);

            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    LastPolygon.Add(new Point(mousePos.X, LastPolygon[LastPolygon.Count - 1].Y));
                }
                else
                {
                    LastPolygon.Add(mousePos);
                }

                UpdateYgroup();

                if (mousePos.Y > max_coord.Y)
                    max_coord = mousePos;
                if (mousePos.Y < min_coord.Y)
                    min_coord = mousePos;

                DrawEdgeStatic();
            }

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                UpdateYgroup(true);
                DrawEdgeStatic(true);
                Polygons.Add(new List<Point>());
                LastPolygon = Polygons[Polygons.Count - 1];
            }
        }

        // Внести последнее ребро в соответствующую y-группу
        private void UpdateYgroup(bool last = false)
        {
            int size = LastPolygon.Count;
            if (size >= 2 && (ModifierKeys != Keys.Control))
            {
                Point a = LastPolygon[size - 1];
                Point b;
                if (!last)
                    b = LastPolygon[size - 2];
                else
                    b = LastPolygon[0];
                
                int dy = a.Y - b.Y;
                float dx = (a.X - b.X) / (float)dy;

                if (dy < 0) // точка "a" выше
                {
                    y_group[a.Y].Add(new Edge(dy * -1, a.X, dx));
                }
                else if (dy > 0) 
                {
                    y_group[b.Y].Add(new Edge(dy, b.X, dx));
                }
            }
        }

        // Закраска
        private void buttonFill_Click(object sender, EventArgs e)
        {
            for (int i = min_coord.Y; i < max_coord.Y; i++)
            {
                ActiveEdges.AddYgroup(y_group[i]);
                ActiveEdges.Draw(g, pen, i);
                ActiveEdges.Update();
            }
        }
    }
}
