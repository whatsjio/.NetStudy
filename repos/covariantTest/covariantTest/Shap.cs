using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariantTest
{
    public  class Shap
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString() => $"Width:{Width},Height:{Height}";

       
    }
    public class Rectangle : Shap {

    }
    public interface IIndex<out T> {
        T this[int index] { get; }
        int Count { get; }
    }
    public class RectangleCollection : IIndex<Rectangle> {
        private Rectangle[] data = new Rectangle[3] {
            new Rectangle{ Height=2,Width=5 },
            new Rectangle{ Height=3,Width=7 },
            new Rectangle{ Height=4.5,Width=2.9 }
        };
        private static RectangleCollection _coll;
        public static RectangleCollection GetRectangle() => _coll ?? (_coll = new RectangleCollection());
        public Rectangle this[int index] {
            get {
                if (index<0|| index> data.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return data[index];
            }

        }
        public int Count => data.Length;
    }
}

