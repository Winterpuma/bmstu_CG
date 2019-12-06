using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_09
{
    class Cutter
    {
        private List<PointF> W;
        private List<Vector> normal;
        private bool finished_input = false;
        private int walk_direction = 0;

        public Cutter()
        {
            W = new List<PointF>();
            normal = new List<Vector>();
        }

        public void AddVertex(PointF dot)
        {
            W.Add(dot);
        }
        public void AddVertex(float x, float y)
        {
            W.Add(new PointF(x, y));
        }

        public void Clear()
        {
            W.Clear();
            normal.Clear();
            finished_input = false;
            walk_direction = 0;
        }

        // Закончен ввод отсекателя
        public void Finish()
        {
            finished_input = true;
            walk_direction = ConvexityCheck();
            FindNormalVectors(walk_direction);
        }

        public bool IsFinished()
        {
            return finished_input;
        }

        public bool IsEmpty()
        {
            return true ? (W.Count == 0) : false;
        }

        // Получение вершины по индексу
        public PointF GetVertex(int index)
        {
            if (index < 0)
                return W[W.Count + index]; // Вершина с конца
            else
                return W[index % W.Count];
        }

        // Проверка выпуклости; возвращает направление обхода
        private int ConvexityCheck()
        {
            if (W.Count < 3)
                return 0;

            Vector a = new Vector(W[1], W[0]);
            Vector b = new Vector();
            Vector res = new Vector();

            int sign = 0;

            for (int i = 0; i < W.Count; i++)
            {
                b = new Vector(GetVertex(i + 1), GetVertex(i));
                Vector.VectorMultiplication(a, b, ref res);

                if (sign == 0)
                    sign = Math.Sign(res.z);
                else if ((sign != Math.Sign(res.z)) && (res.z != 0))
                    return 0;

                a = b;
            }

            if (sign == 0) // Вырождается в линию
                return 0;

            return sign;
        }

        public bool IsConvex()
        {
            if (walk_direction == 0)
                return false;
            return true;
        }

        // Нахождение векторов нормали для отсекателя
        private void FindNormalVectors(int direction)
        {
            Vector b;
            float tmp;
            normal.Clear();

            for (int i = 0; i < W.Count; i++)
            {
                b = new Vector(GetVertex(i + 1), GetVertex(i));

                tmp = b.x;
                b.x = b.y;
                b.y = tmp;

                if (direction == -1)
                    b.y *= -1;
                else
                    b.x *= -1;


                normal.Add(b);
            }
        }

        /*
        // Алгоритм Кируса-Бека по отсечению отрезка
        public Segment CutCyrusBeck(Segment l)
        {

            float t_down = 0, t_up = 1;
            float t_tmp;

            Vector D = new Vector(l.end, l.start);
            Vector w;

            float D_sc;
            float W_sc;

            for (int i = 0; i < W.Count; i++)
            {
                w = new Vector(l.start, W[i]);
                D_sc = Vector.ScalarMultiplication(D, normal[i]);
                W_sc = Vector.ScalarMultiplication(w, normal[i]);

                if (D_sc == 0) // отрезок выродился в точку / D и сторона парралельны
                {
                    if (W_sc < 0)
                        return new Segment();
                    // точка видима относительно текущей границы
                }
                else
                {
                    t_tmp = -1 * (W_sc / D_sc);
                    if (D_sc > 0) // поиск нижнего предела
                    {
                        if (t_tmp > 1)
                            return new Segment();
                        t_down = Math.Max(t_down, t_tmp);
                    }
                    else // поиск верхнего предела
                    {
                        if (t_tmp < 0)
                            return new Segment();
                        t_up = Math.Min(t_up, t_tmp);
                    }
                }
            }

            if (t_down > t_up)
                return new Segment();

            return new Segment(l.GetDot(t_down), l.GetDot(t_up));
        }*/

        // Алгоритм Сазерленда-Ходжмана для отсечения полигонов
        public List<PointF> CutSutherlandHodgman(List<PointF> P)
        {
            List<PointF> Q = new List<PointF>();
            P.Add(P[0]);
            
            PointF S = new PointF();
            PointF I = new PointF();

            double Dsk, Wsk, t;

            for (int i = 0; i < W.Count; i++) // по всем сторонам отсекателя
            {
                if (Vector.VisibleVertex(P[0], W[i], normal[i]))
                    Q.Add(P[0]);
                for (int j = 1; j < P.Count(); j++) // по всем сторонам многоугольника
                {
                    Vector D = new Vector(P[j], P[j-1]); // Вектор нашего отрезка
                    Dsk = Vector.ScalarMultiplication(D, normal[i]); //показывает угол и с какой стороны угол

                    if (Dsk != 0) // Провека, что не точка и не парралельно
                    {
                        Vector WV = new Vector(P[j-1], W[i]); //вектор соединяющий  начало отрезка и вершину многоугольника                                                                      
                        Wsk = Vector.ScalarMultiplication(WV, normal[i]);
                        t = -Wsk / Dsk;
                        if (t >= 0 && t <= 1)  // заменить проверку на проверку знаков видимости точек
                        {
                            I = new Segment(P[j-1], P[j]).GetDot(t);//точка пересечения
                            Q.Add(I);
                        }
                    }
                    
                    if (Vector.VisibleVertex(P[j], W[i], normal[i]))
                        Q.Add(P[j]);
                }

                Q.Add(Q[0]);
                P.Clear();
                P.AddRange(Q);
            

                Q.Clear();
            }

            return P;
        }
    }
}
