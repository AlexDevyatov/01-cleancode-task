using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Testing
{
    internal class Program
    {
        private static void Main()
        {
            //RunTest();
            //return;
            var board = new BoardOfChess();


            board.ReadFromConsole();

            bool isShah = false, isMat = false, isPat = false;

            isMat = board.CheckMat(ColorFigure.White);
            isPat = board.CheckPat(ColorFigure.White);
            isShah = board.CheckShah(ColorFigure.White);


            if (isMat)
                Console.Write("mate");
            else if (isPat)
                Console.Write("stalemate");
            else
                Console.Write(isShah ? "check" : "ok");
        }


        private static void RunTest()
        {
            var board = new BoardOfChess();
            var tests = new List<List<Figure>>();
            var correct = new List<bool[]>();
            var outdate = new List<bool[]>();
            var dontCorrectTest = new List<int>();
            //result :Mat,Pat,Shah

            //Test0
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 4), ColorFigure.White, board),
                              new Rook(new Cell(0, 0), ColorFigure.Black, board),
                              new Rook(new Cell(1, 1), ColorFigure.Black, board),
                              new Rook(new Cell(7, 0), ColorFigure.White, board),
                          });
            //Result
            correct.Add(new[] {false, false, true});

            //Test1
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 4), ColorFigure.White, board),
                              new Rook(new Cell(0, 0), ColorFigure.Black, board),
                              new Rook(new Cell(1, 1), ColorFigure.Black, board),
                              new Rook(new Cell(7, 3), ColorFigure.White, board),
                          });
            //Result
            correct.Add(new[] {false, false, true});

            //Test2
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 4), ColorFigure.White, board),
                              new Rook(new Cell(0, 0), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, false, true});

            //Test3
            tests.Add(new List<Figure>
                          {
                              new Rook(new Cell(0, 0), ColorFigure.White, board),
                              new Nag(new Cell(1, 0), ColorFigure.White, board),
                              new Bishop(new Cell(2, 0), ColorFigure.White, board),
                              new King(new Cell(3, 0), ColorFigure.White, board),
                              new Quine(new Cell(4, 0), ColorFigure.White, board),
                              new Bishop(new Cell(5, 0), ColorFigure.White, board),
                              new Nag(new Cell(6, 0), ColorFigure.White, board),
                              new Rook(new Cell(7, 0), ColorFigure.White, board),
                              new Rook(new Cell(0, 7), ColorFigure.Black, board),
                              new Nag(new Cell(1, 7), ColorFigure.Black, board),
                              new Bishop(new Cell(2, 7), ColorFigure.Black, board),
                              new King(new Cell(3, 7), ColorFigure.Black, board),
                              new Quine(new Cell(4, 7), ColorFigure.Black, board),
                              new Bishop(new Cell(5, 7), ColorFigure.Black, board),
                              new Nag(new Cell(6, 7), ColorFigure.Black, board),
                              new Rook(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, false, false});

            //Test4
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Rook(new Cell(7, 0), ColorFigure.Black, board),
                              new Rook(new Cell(6, 1), ColorFigure.Black, board),
                              new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {true, false, true});

            //Test5
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Rook(new Cell(7, 1), ColorFigure.Black, board),
                              new Rook(new Cell(1, 7), ColorFigure.Black, board),
                              //new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});

            //Test6
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Quine(new Cell(1, 1), ColorFigure.White, board),
                              new Rook(new Cell(7, 1), ColorFigure.Black, board),
                              new Rook(new Cell(1, 7), ColorFigure.Black, board),
                              //new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, false, false});

            //Test7
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Quine(new Cell(1, 1), ColorFigure.Black, board),
                              new Rook(new Cell(7, 1), ColorFigure.Black, board),
                              new Rook(new Cell(1, 7), ColorFigure.Black, board),
                              //new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {true, false, true});

            //Test8
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Bishop(new Cell(2, 2), ColorFigure.White, board),
                              new Quine(new Cell(1, 1), ColorFigure.Black, board),
                              new Rook(new Cell(7, 1), ColorFigure.Black, board),
                              new Rook(new Cell(1, 7), ColorFigure.Black, board),
                              //new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, false, true});

            //Test9
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(1, 0), ColorFigure.White, board),
                              new Bishop(new Cell(1, 1), ColorFigure.White, board),
                              new Quine(new Cell(0, 7), ColorFigure.Black, board),
                              new Rook(new Cell(1, 7), ColorFigure.Black, board),
                              new Rook(new Cell(2, 7), ColorFigure.Black, board),
                              //new King(new Cell(7, 7), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});

            //Test10 ��� ����� �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new King(new Cell(1, 2), ColorFigure.Black, board),
                              new Bishop(new Cell(2, 2), ColorFigure.Black, board),
                              new Bishop(new Cell(3, 2), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {true, false, true});

            //Test11 ��� ����� �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 1), ColorFigure.White, board),
                              new King(new Cell(2, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(1, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(2, 3), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {true, false, true});

            //Test12 ��� ����� ������� � �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new King(new Cell(1, 2), ColorFigure.Black, board),
                              new Bishop(new Cell(3, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(3, 2), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});

            //Test13 ��� ����� �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 1), ColorFigure.White, board),
                              new King(new Cell(2, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(1, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(3, 2), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});

            //Test14 ��� ����� �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(2, 0), ColorFigure.White, board),
                              new King(new Cell(0, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(2, 2), ColorFigure.Black, board),
                              new Bishop(new Cell(1, 2), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});

            //Test14 ��� ����� �������
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(1, 0), ColorFigure.White, board),
                              new King(new Cell(0, 2), ColorFigure.Black, board),
                              new Bishop(new Cell(1, 1), ColorFigure.Black, board),
                              new Bishop(new Cell(1, 2), ColorFigure.Black, board),
                          });
            //Result
            correct.Add(new[] {false, true, false});
            //Test15 ��� �����
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(4, 5), ColorFigure.White, board),
                              new Nag(new Cell(3, 3), ColorFigure.Black, board)
                          });
            //Result
            correct.Add(new[] {false, false, true});

            //Test16 ��� �����
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(4, 5), ColorFigure.White, board),
                              new Nag(new Cell(5, 7), ColorFigure.Black, board)
                          });
            //Result
            correct.Add(new[] {false, false, true});
            //Test16 ��� �����
            tests.Add(new List<Figure>
                          {
                              new King(new Cell(0, 0), ColorFigure.White, board),
                              new Rook(new Cell(1, 0), ColorFigure.White, board),
                              new Bishop(new Cell(0, 1), ColorFigure.White, board),
                              new Bishop(new Cell(1, 1), ColorFigure.White, board),
                              new Nag(new Cell(2, 1), ColorFigure.Black, board)
                          });
            //Result
            correct.Add(new[] {true, false, true});

            //������������
            for (int i = 0; i < tests.Count; i++)
            {
                Console.Out.WriteLine(String.Format("Test:{0}", i));
                board.AddFigures(tests[i]);
                Console.Out.WriteLine(board.ToString());


                bool isMat = board.CheckMat(ColorFigure.White);
                bool isPat = board.CheckPat(ColorFigure.White);
                bool isShah = board.CheckShah(ColorFigure.White);

                outdate.Add(new[] {isMat, isPat, isShah});

                bool result = (isMat == correct[i][0] && isPat == correct[i][1] && isShah == correct[i][2]);
                if (result == false) dontCorrectTest.Add(i);
                board.RemoveAllFigures();
            }
            //����
            if (dontCorrectTest.Count == 0)
            {
                Console.WriteLine("OKEY!!!");
            }
            else


                dontCorrectTest.ForEach(
                    er => Console.WriteLine(
                        "ErrorTest:{0}.Mat:{1}({2}).Pat{3}({4}).Shah{5}({6})",
                        er,
                        outdate[er][0],
                        correct[er][0],
                        outdate[er][1],
                        correct[er][1],
                        outdate[er][2],
                        correct[er][2]));
            Console.ReadLine();
        }
    }
}

namespace Testing
{
    public class Cell
    {
        /// <summary>
        /// ������ ���������� ������
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public static bool operator ==(Cell curCell, Cell otherCell)
        {
            if ((object) curCell == null && (object) otherCell == null)
                return true;
            if ((object) curCell == null || (object) otherCell == null)
                return false;
            return curCell.X == otherCell.X && curCell.Y == otherCell.Y;
        }

        public static bool operator !=(Cell curCell, Cell otherCell)
        {
            if ((object) curCell == null || (object) otherCell == null)
                return (object) curCell != null || (object) otherCell != null;
            return curCell.X != otherCell.X || curCell.Y != otherCell.Y;
        }

        public static Cell operator *(Cell curCell, int alfa)
        {
            return new Cell(curCell.X*alfa, curCell.Y*alfa);
        }

        public Cell Apply(Cell offset)
        {
            return new Cell(X + offset.X, Y + offset.Y);
        }

        public override string ToString()
        {
            return (X.ToString(CultureInfo.InvariantCulture) + ":" + Y.ToString(CultureInfo.InvariantCulture));
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Cell)) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }
}

namespace Testing
{
    public class BoardOfChess
    {
        /// <summary>
        /// ����������� ��������� ����� �� ������������ ��������� (8 x 8)
        /// </summary>
        public BoardOfChess()
        {
            Figures = new List<Figure>();
            MaxSizeX = MaxSizeY = 8;
        }

        /// <summary>
        /// ����������� �������� ������������� ������� �����
        /// </summary>
        /// <param name="maxSizeX"></param>
        /// <param name="maxSizeY"></param>
        public BoardOfChess(int maxSizeX, int maxSizeY)
        {
            Figures = new List<Figure>();
            MaxSizeX = maxSizeX;
            MaxSizeY = maxSizeY;
        }

        /// <summary>
        /// ������ ����������� �� �����
        /// </summary>
        public List<Figure> Figures { get; private set; }

        /// <summary>
        /// ������ ����� �� ��� OX
        /// </summary>
        public int MaxSizeX { get; private set; }

        /// <summary>
        /// ������ ����� �� ��� OY
        /// </summary>
        public int MaxSizeY { get; private set; }

        /// <summary>
        /// ������� �������  ��������� ���������� �� Console.In � ���������� � Console.Out ����� ���\���\���\��
        /// </summary>
        public void ReadFromConsole()
        {
            for (int i = 0; i < MaxSizeY; i++)
            {
                string str = Console.In.ReadLine();
                for (int j = 0; j < MaxSizeX; j++)
                {
                    if (str[j] == '.')
                        continue;

                    ColorFigure color = (str[j] >= 'A' && str[j] <= 'Z') ? ColorFigure.White : ColorFigure.Black;
                    switch (str[j].ToString().ToUpper())
                    {
                        case "N":
                            AddFigure(new Nag(new Cell(j, i), color, this));
                            break;
                        case "B":
                            AddFigure(new Bishop(new Cell(j, i), color, this));
                            break;
                        case "R":
                            AddFigure(new Rook(new Cell(j, i), color, this));
                            break;
                        case "Q":
                            AddFigure(new Quine(new Cell(j, i), color, this));
                            break;
                        case "K":
                            AddFigure(new King(new Cell(j, i), color, this));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// ���������� ����� ������ � ����
        /// </summary>
        /// <param name="newFigure"></param>
        public void AddFigure(Figure newFigure)
        {
            //�������� ����� �� �� ���� ������� ������ ������ ��� ���
            foreach (Figure f in Figures)
                if (f.Location == newFigure.Location)
                {
                    Console.Out.WriteLine(String.Format("�� ������� ({0},{1}) ��� ����� {2}", f.Location.X, f.Location.Y,
                                                        f.Name));
                    return;
                }
            Figures.Add(newFigure);
        }

        /// <summary>
        /// ���������� ���s� �����
        /// </summary>
        /// <param name="figures">������ ����� ������� ����� ��������</param>
        public void AddFigures(List<Figure> figures)
        {
            //�������� ����� �� �� ���� ������� ������ ������ ��� ���
            foreach (Figure newFigure in figures)
            {
                bool isDontExist = true;
                foreach (Figure f in Figures)
                    if (f.Location == newFigure.Location)
                    {
                        Console.Out.WriteLine(String.Format("�� ������� ({0},{1}) ��� ����� {2}", f.Location.X,
                                                            f.Location.Y, f.Name));
                        isDontExist = false;
                    }
                if (isDontExist)
                    Figures.Add(newFigure);
            }
        }

        /// <summary>
        /// �������� ������ � �����
        /// </summary>
        /// <param name="possition"></param>
        public void RemoveFigure(Cell possition)
        {
            foreach (Figure f in Figures)
            {
                if (f.Location.X == possition.X && f.Location.Y == possition.Y)
                {
                    Console.Out.WriteLine(String.Format("������ <{0}> �������.", f.Name));
                    Figures.Remove(f);
                    return;
                }
                Console.Out.WriteLine("�� ������ ������� ��� �����");
            }
        }

        /// <summary>
        /// �������� �����
        /// </summary>
        public void RemoveAllFigures()
        {
            Figures = new List<Figure>();
        }

        /// <summary>
        /// ������� ������������ ����� �� �����. (ASCII-art)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = " |";
            for (int i = 0; i < MaxSizeX; i++)
                result += (i + 1).ToString(CultureInfo.InvariantCulture) + '|';
            result += Environment.NewLine;
            for (int i = 0; i < MaxSizeY; i++)
            {
                for (int z = 0; z < (MaxSizeX + 1)*2; z++)
                    result += '-';
                result += Environment.NewLine + (i + 1).ToString(CultureInfo.InvariantCulture) + "|";
                for (int j = 0; j < MaxSizeX; j++)
                {
                    Figure a = Figures.FirstOrDefault(f => f.Location.X == j && f.Location.Y == i);
                    if (a == null)
                        result += " |";
                    else
                    {
                        if (a.Color == ColorFigure.Black)
                            result += a.Name.ToString()[0].ToString(CultureInfo.InvariantCulture).ToLower() + '|';
                        else
                            result += a.Name.ToString()[0].ToString(CultureInfo.InvariantCulture).ToUpper() + '|';
                    }
                }
                result += Environment.NewLine;
            }
            return result;
        }

        /// <summary>
        /// ��������� ��������� �� ������ ��� �����
        /// </summary>
        /// <param name="whom">���� ������</param>
        /// <returns>true-���\false-��� ����</returns>
        public bool CheckShah(ColorFigure whom)
        {
            //���� ������
            Figure king = Figures.FirstOrDefault(f => f.Color == whom && f.Name == NameFigure.King);
            if (king == null)
                throw new Exception(whom + " king is dont exists on board");
            //���������� ��������� ������    
            return
                Figures.Where(f => f.Color != whom).Any(
                    f => f.GetMoves().FirstOrDefault(cell => (cell == king.Location)) != null);
        }

        /// <summary>
        /// ��������� ��������� �� ��� ������
        /// </summary>
        /// <param name="whom">���� ������</param>
        /// <returns>true-���\false- ���� ���</returns>
        public bool CheckMat(ColorFigure whom)
        {
            //���� ������
            Figure king = Figures.FirstOrDefault(f => f.Color == whom && f.Name == NameFigure.King);
            if (king == null)
                throw new Exception(whom + " king is dont exists on board");

            if (CheckShah(whom)) //���� ��� ���, �� �������� ���
            {
                bool isMat = true;
                foreach (Figure figure in Figures.Where(f => f.Color == whom).ToList())
                {
                    foreach (Cell newLocation in figure.GetMoves().ToList())
                    {
                        Cell oldLocation = figure.Location; //���������� ��� ������ ������ ������
                        Figure figureOnNewPlace = figure.Move(newLocation);
                        //����������� ������ �� ����� ��������� �����(���� ��� ������ ������ ������ ������ ��

                        if (CheckShah(whom) == false)
                            //���� ��� ����������� ������ ���� ������ ���.. �� ������ � ���� ���
                            isMat = false;
                        //���������� ������ �� ������� �����
                        figure.Move(
                            oldLocation);
                        if (figureOnNewPlace != null)
                            AddFigure(figureOnNewPlace);
                        if (!isMat)
                            return false;
                    }
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// ��������� �� ��������� �� ��� ������
        /// </summary>
        /// <param name="whom">���� ������</param>
        /// <returns>true-���, false-���� ���</returns>
        public bool CheckPat(ColorFigure whom)
        {
            Figure king = Figures.FirstOrDefault(f => f.Color == whom && f.Name == NameFigure.King);
            if (king == null)
                throw new Exception(whom + " king is dont exists on board");
            //�������� ��� �� ���� ������ �� ������� ��� ������
            if (!CheckShah(whom))
                //����� �� ���� ���� ������ ������ ������ �����
            {
                bool isPat = true;
                foreach (Figure figure in Figures.Where(f => f.Color == whom).ToList()) //���������� ���� ������
                {
                    foreach (Cell newLocation in figure.GetMoves()) //�������� ������ ������ ���� ������ ����� �������
                    {
                        Cell oldLocation = figure.Location; //���������� ��� ������ ������ ������
                        Figure figureOnNewPlace = figure.Move(newLocation);
                        //����������� ������ �� ����� ��������� �����(���� ��� ������ ������ ������ ������ ��

                        if (CheckShah(whom) == false)
                            //���� ��� ����������� ������ ���� ��� ������ ��� ��� ���� ���� ���
                            isPat = false;
                        //���������� ������ �� ������� �����
                        figure.Move(
                            oldLocation);
                        if (figureOnNewPlace != null)
                            AddFigure(figureOnNewPlace);
                        if (!isPat)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}

namespace Testing
{
    internal class Bishop : INMFigure
    {
        public Bishop(Cell location, ColorFigure color, BoardOfChess board)
            : base(location, NameFigure.Bishop, color, board)
        {
        }

        public override List<Cell> GetMoves()
        {
            var firstOffset = new[]
                                  {
                                      new Cell(-1, 1),
                                      new Cell(-1, -1),
                                      new Cell(1, 1),
                                      new Cell(1, -1)
                                  };
            return base.GetOffset(firstOffset.ToList());
        }
    }
}

namespace Testing
{
    /// <summary>
    /// �������� �����
    /// </summary>
    public enum NameFigure
    {
        King, //������
        Bishop, //����
        Nag, //����
        Quine, //��������
        Rook //�����
    }

    /// <summary>
    /// ����� �������
    /// </summary>
    public enum ColorFigure
    {
        Black, //������
        White //�����
    }

    /// <summary>
    /// ����� ����� ��� ���
    /// </summary>
    public abstract class Figure
    {
        protected Figure(Cell location, NameFigure name, ColorFigure color, BoardOfChess board)
        {
            Location = location;
            Name = name;
            Color = color;
            Board = board;
        }

        /// <summary>
        /// ������� ������ �� �����
        /// </summary>
        public Cell Location { get; private set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        public NameFigure Name { get; private set; }

        /// <summary>
        /// ���� ������
        /// </summary>
        public ColorFigure Color { get; private set; }

        /// <summary>
        /// ����� �� ������� ����� ������
        /// �����?! ����� �� ������ �� ���� ������)
        /// </summary>
        public BoardOfChess Board { get; private set; }

        /// <summary>
        /// ����� ���������� ��������� ����������� ������ �� �����(��� �������� � ��������� ����)
        /// </summary>
        /// <returns>������ ������� ���� ����� ������������ ������</returns>
        public abstract List<Cell> GetMoves();

        /// <summary>
        /// ����� ��������� ��������� �������� ������ �������� ������� ���� ������ �����  ����������
        /// </summary>
        /// <param name="firstOffset"></param>
        /// <returns></returns>
        protected abstract List<Cell> GetOffset(List<Cell> firstOffset);

        /// <summary>
        /// ����� ����������� ������ �� ����� �������. ���� �� ����� ������ ������ ������ ������ �� ��� ��������� �� ������ �����.. � ������������ �������
        /// </summary>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public Figure Move(Cell newLocation)
        {
            Figure figureOnNewLocaion = Board.Figures.FirstOrDefault(f => f.Location == newLocation);
            if (figureOnNewLocaion != null)
                Board.Figures.Remove(figureOnNewLocaion);
            Board.Figures.FirstOrDefault(f => this == f).Location = newLocation; //����������� ������
            return figureOnNewLocaion;
        }

        /// <summary>
        /// ������ ����� � �������� ������� cells *- ����� ���� ����� ������� ������
        /// ����� ��������� ��� ������
        /// </summary>
        /// <param name="cells">����� ������� ����� ��������� *</param>
        /// <returns>���� �������� ASCII-art</returns>
        public string Show(List<Cell> cells)
        {
            string result = " |";
            for (int i = 0; i < Board.MaxSizeX; i++)
                result += (i + 1).ToString(CultureInfo.InvariantCulture) + '|';
            result += Environment.NewLine;
            for (int i = 0; i < Board.MaxSizeY; i++)
            {
                for (int z = 0; z < (Board.MaxSizeX + 1)*2; z++)
                    result += '-';
                result += Environment.NewLine + (i + 1).ToString(CultureInfo.InvariantCulture) + "|";

                for (int j = 0; j < Board.MaxSizeX; j++)
                {
                    Figure a = Board.Figures.FirstOrDefault(f => f.Location.X == j && f.Location.Y == i);
                    if (a == null)
                    {
                        Cell cell = cells.FirstOrDefault(f => f.X == j && f.Y == i);
                        if (cell != null)
                            result += "*|";
                        else
                            result += " |";
                    }
                    else
                    {
                        if (a.Color == ColorFigure.Black)
                            result += a.Name.ToString()[0].ToString(CultureInfo.InvariantCulture).ToLower() + '|';
                        else
                            result += a.Name.ToString()[0].ToString(CultureInfo.InvariantCulture).ToUpper() + '|';
                    }
                }


                result += Environment.NewLine;
            }
            return result;
        }
    }

    /// <summary>
    /// ����������� ����� ����� ������� �������� ���������� ����� 
    /// </summary>
    public abstract class FNMFigure : Figure
    {
        protected FNMFigure(Cell location, NameFigure name, ColorFigure color, BoardOfChess board)
            : base(location, name, color, board)
        {
        }

        protected override List<Cell> GetOffset(List<Cell> firstOffset)
        {
            var allowableOffset = new List<Cell>();
            foreach (Cell t in firstOffset)
            {
                Cell newPos = t.Apply(Location);
                //��������� �� ��� �������� ����� �� �����
                if (newPos.X >= 0 && newPos.X < Board.MaxSizeX && newPos.Y >= 0 && newPos.Y < Board.MaxSizeY)
                {
                    //��������� �� ����� �� ��� ���� ������
                    bool isAllowCell = true;
                    foreach (Figure f in Board.Figures)
                        if (f.Location == newPos)
                        {
                            if (f.Color == Color) //���� ������ ���� ������                         
                                isAllowCell = false;
                            break;
                        }
                    if (isAllowCell)
                        allowableOffset.Add(newPos);
                }
            }
            return allowableOffset;
        }
    }

    /// <summary>
    /// ����������� ����� �����, ������ ���������� � ������������ �����������. � firstOfSet -�������� ������ ���� ����� �����
    /// </summary>
    public abstract class INMFigure : Figure
    {
        protected INMFigure(Cell location, NameFigure name, ColorFigure color, BoardOfChess board)
            : base(location, name, color, board)
        {
        }

        protected override List<Cell> GetOffset(List<Cell> firstOffset)
        {
            var allowableOffset = new List<Cell>();
            int r = 1;
            while (firstOffset.Count != 0)
            {
                var deleteOffSet = new List<Cell>();
                foreach (Cell c in firstOffset)
                {
                    Cell newPos = (c*r).Apply(Location);
                    //��������� �� ��� �������� ����� �� �����
                    bool isCloseWay = false; // ���� ������� �� �� ����� ������  ��������
                    bool isAllowCell = true; //��������� �� ������
                    if (newPos.X >= 0 && newPos.X < Board.MaxSizeX && newPos.Y >= 0 && newPos.Y < Board.MaxSizeY)
                    {
                        //�� ����� �� �� ����� ������� ������
                        foreach (Figure f in Board.Figures)
                            if (f.Location == newPos)
                            {
                                isCloseWay = true;
                                if (f.Color == Color) //���� ������ ���� ������
                                    isAllowCell = false;
                                break;
                            }
                        if (isAllowCell)
                            allowableOffset.Add(newPos);
                        if (isCloseWay)
                            deleteOffSet.Add(c);
                    }
                    else
                        deleteOffSet.Add(c);
                }
                deleteOffSet.ForEach(c => firstOffset.Remove(c));
                r++;
            }
            return allowableOffset;
        }
    }
}

namespace Testing
{
    internal class King : FNMFigure
    {
        public King(Cell location, ColorFigure color, BoardOfChess board)
            : base(location, NameFigure.King, color, board)
        {
        }

        public override List<Cell> GetMoves()
        {
            var firstOffset = new[]
                                  {
                                      new Cell(-1, 1),
                                      new Cell(1, 1),
                                      new Cell(1, 0),
                                      new Cell(1, -1),
                                      new Cell(0, -1),
                                      new Cell(0, 1),
                                      new Cell(-1, -1),
                                      new Cell(-1, 0)
                                  };
            return base.GetOffset(firstOffset.ToList());
        }
    }
}

namespace Testing
{
    internal class Nag : FNMFigure
    {
        public Nag(Cell location, ColorFigure color, BoardOfChess board) : base(location, NameFigure.Nag, color, board)
        {
        }

        public override List<Cell> GetMoves()
        {
            var firstOffset = new[]
                                  {
                                      new Cell(1, 2),
                                      new Cell(2, 1),
                                      new Cell(2, -1),
                                      new Cell(1, -2),
                                      new Cell(-1, -2),
                                      new Cell(-2, -1),
                                      new Cell(-2, 1),
                                      new Cell(-1, 2)
                                  };
            return base.GetOffset(firstOffset.ToList());
        }
    }
}

namespace Testing
{
    internal class Quine : INMFigure
    {
        public Quine(Cell location, ColorFigure color, BoardOfChess board)
            : base(location, NameFigure.Quine, color, board)
        {
        }

        public override List<Cell> GetMoves()
        {
            var firstOffset = new[]
                                  {
                                      new Cell(-1, 1),
                                      new Cell(1, 1),
                                      new Cell(1, 0),
                                      new Cell(0, 1),
                                      new Cell(1, -1),
                                      new Cell(0, -1),
                                      new Cell(-1, -1),
                                      new Cell(-1, 0)
                                  };
            return base.GetOffset(firstOffset.ToList());
        }
    }
}

namespace Testing
{
    public class Rook : INMFigure
    {
        public Rook(Cell location, ColorFigure color, BoardOfChess board)
            : base(location, NameFigure.Rook, color, board)
        {
        }

        public override List<Cell> GetMoves()
        {
            var firstOffset = new[]
                                  {
                                      new Cell(0, 1),
                                      new Cell(-1, 0),
                                      new Cell(1, 0),
                                      new Cell(0, -1)
                                  };

            return base.GetOffset(firstOffset.ToList());
        }
    }
}