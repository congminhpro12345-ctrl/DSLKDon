

namespace DSLKDon
{
    internal class IntNode
    {
       
            private int data;
            private IntNode next;

            public int Data { get { return data; } set { data = value; } }
            public IntNode Next { get { return next; } set { next = value; } }

            public IntNode()
            {
                data = 0;
                next = null;
            }

            public IntNode(int x)
            {
                data = x;
                next = null;
            }
      


    }

}
