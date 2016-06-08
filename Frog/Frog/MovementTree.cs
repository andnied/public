using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frog
{
    public class MovementTree
    {
        private readonly int _number;

        public MovementTree(int number)
        {
            _number = number;
        }

        public MovementTree Left { get; set; }
        public MovementTree Right { get; set; }

        public void FillNodes()
        {
            if ((_number - 1) >= 0)
            {
                Left = new MovementTree(_number - 1);
                Left.FillNodes();
            }
            
            if ((_number - 2) >= 0)
            {
                Right = new MovementTree(_number - 2);
                Right.FillNodes();
            }
        }

        public int CountPaths()
        {
            int sum = 0;

            if (Left == null && Right == null)
                return 1;
            else
            {
                if (Left != null)
                    sum = Left.CountPaths();
                if (Right != null)
                    sum += Right.CountPaths();
            }

            return sum;
        }
    }
}