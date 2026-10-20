using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class MyList
    {
        private IntNode first;
        private IntNode last;
        private int count;

        public IntNode First { get { return first; } set { first = value; } }
        public IntNode Last { get { return last; } set { last = value; } }
        public int Count { get { return count; } set { count = value; } }

        public MyList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
        public void AddFirst(IntNode newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                newNode.Next = first;
                first = newNode;
            }
            count++;
        }

        public void AddLast(IntNode newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                last.Next = newNode;
                last = newNode;
            }
            count++;
        }
        public void Input_Front()
        {
            int x;
            while (true)
            {
                Console.Write("x (0 to stop) = ");
                int.TryParse(Console.ReadLine(), out x);
                if (x == 0)
                    break;
                AddFirst(new IntNode(x));
            }
        }

        public void Input_Last()
        {
            int x;
            while (true)
            {
                Console.Write("x (0 to stop) = ");
                int.TryParse(Console.ReadLine(), out x);
                if (x == 0)
                    break;
                AddLast(new IntNode(x));
            }
        }
        public void ShowList()
        {
            IntNode p = first;
            while (p != null)
            {
                Console.Write("{0} -> ", p.Data);
                p = p.Next;
            }
            Console.WriteLine("null");
        }
        public IntNode SearchX(int x)
        {
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (p.Data == x)
                    return p;
            }
            return null;
        }

        public IntNode GetMax()
        {
            IntNode max = first;
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (p.Data > max.Data)
                    max = p;
            }
            return max;
        }

        public IntNode GetMin()
        {
            IntNode min = first;
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (p.Data < min.Data)
                    min = p;
            }
            return min;
        }
        public MyList GetEvenList()
        {
            MyList evenList = new MyList();
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (p.Data % 2 == 0)
                    evenList.AddLast(new IntNode(p.Data));
            }
            return evenList;
        }

        public MyList GetOddList()
        {
            MyList oddList = new MyList();
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (p.Data % 2 != 0)
                    oddList.AddLast(new IntNode(p.Data));
            }
            return oddList;
        }
        public IntNode Search_At_i(int i)
        {
            int viTri = 0;
            for (IntNode p = first; p != null; p = p.Next)
            {
                if (viTri == i)
                    return p;
                viTri++;
            }
            return null;
        }
       
        public void Input_Front_NotDuplicate()
        {
            int x;
            while (true)
            {
                Console.Write("x (0 to stop) = ");
                x = int.Parse(Console.ReadLine());

                if (x == 0)                          // (1) 0 là giá trị dừng: kiểm tra trước
                    break;

                if (SearchX(x) != null)              // (2) x đã có trong danh sách?
                {
                    Console.WriteLine("Gia tri {0} da ton tai, hay nhap gia tri khac!", x);
                    continue;                        //     bỏ qua vòng này, KHÔNG thêm node
                }

                AddFirst(new IntNode(x));            // (3) x chưa có: thêm vào đầu
            }
        }
        public void Input_Last_NotDuplicate()
        {
            int x;
            while (true)
            {
                Console.Write("x (0 to stop) = ");
                x = int.Parse(Console.ReadLine());

                if (x == 0)
                    break;

                if (SearchX(x) != null)
                {
                    Console.WriteLine("Gia tri {0} da ton tai, hay nhap gia tri khac!", x);
                    continue;
                }

                AddLast(new IntNode(x));             // Khác duy nhất: AddLast thay cho AddFirst
            }
        }
        
        public void RemoveX(IntNode nodeX)
        {
            if (nodeX == null || IsEmpty())          
                return;

            if (nodeX == first)                     
            {
                first = first.Next;                
                nodeX.Next = null;                  
                if (first == null)                   
                    last = null;
            }
            else if (nodeX == last)                  
            {
                IntNode pTruoc = first;              
                while (pTruoc.Next != nodeX)
                    pTruoc = pTruoc.Next;
                pTruoc.Next = null;                 
                last = pTruoc;
            }
            else                                     
            {
                IntNode pSau = nodeX.Next;          
                nodeX.Data = pSau.Data;              
                nodeX.Next = pSau.Next;              
                if (pSau == last)                    
                    last = nodeX;                    
                pSau.Next = null;                   
            }
        }
        // Xóa node ở vị trí i (đếm từ 0).
        public void RemoveAt(int i)
        {
            IntNode pXoa = Search_At_i(i);           // (1) tìm node cần xóa
            if (pXoa == null)                        // (2) vị trí i không hợp lệ
            {
                Console.WriteLine("Vi tri i khong hop le!");
                return;
            }
            RemoveX(pXoa);                           // (3) tái sử dụng RemoveX để xóa node đó
        }
        public void InsertAt(int x, int i)
        {
            IntNode newNode = new IntNode(x);        // (1) tạo node mới chứa x
            IntNode pChen = Search_At_i(i);          // (2) pChen: node hiện đang ở vị trí i
            if (pChen == null)                       // (3) i không trỏ vào node nào
            {
                if (i == Count)                    //     i = số node: chèn vào cuối
                    AddLast(newNode);
                else
                    Console.WriteLine("Vi tri i khong hop le!");
                return;
            }

            // (4) Chèn newNode SAU pChen (vì pChen.Next có sẵn)
            newNode.Next = pChen.Next;               //     bước 1: newNode nối vào phần đuôi
            pChen.Next = newNode;                    //     bước 2: pChen nối vào newNode

            // (5) Hoán đổi data: giá trị x chuyển lên pChen, giá trị cũ xuống newNode
            int tmp = pChen.Data;
            pChen.Data = newNode.Data;
            newNode.Data = tmp;

            // (6) Nếu pChen từng là node cuối thì node cuối mới là newNode
            if (pChen == last)
                last = newNode;
        }
        public void InsertXAfterY(IntNode nodeX, IntNode nodeY)
        {
            if (nodeX == null || nodeY == null)    // (1) không tìm thấy y thì không chèn được
                return;

            if (nodeY == last)                     // (2) y là node cuối: chính là AddLast
                AddLast(nodeX);
            else
            {
                nodeX.Next = nodeY.Next;           // (3) BƯỚC 1: nodeX nối vào node sau y
                nodeY.Next = nodeX;                //     BƯỚC 2: y nối vào nodeX
            }
        }
        public void InsertXAfterMin(IntNode nodeX)
        {
            IntNode min = GetMin();              // (1) tìm node nhỏ nhất (đã có từ Buổi 4)
            if (min == null)                     // (2) danh sách rỗng: nodeX là node đầu tiên
                AddFirst(nodeX);
            else
                InsertXAfterY(nodeX, min);       // (3) tái sử dụng: chèn nodeX sau node min
        }
        public void ShiftLeft()
        {
            RemoveAt(0);
        }
        public void InsertXBeforeY(IntNode nodeX, IntNode nodeY)
        {
            if (nodeX == null || nodeY == null)    // (1) không tìm thấy y thì không chèn được
                return;

            // Mẹo: chèn SAU rồi hoán đổi data
            InsertXAfterY(nodeX, nodeY);           // (2) bước 1: ... -> y -> x -> ...

            int tmp = nodeX.Data;                  // (3) bước 2: đổi data của x và y
            nodeX.Data = nodeY.Data;               //     node đứng trước giờ chứa giá trị x,
            nodeY.Data = tmp;                      //     node đứng sau chứa giá trị y
        }
        public void InsertXBeforeMax(IntNode nodeX)
        {
            IntNode max = GetMax();                // (1) tìm node lớn nhất (đã có từ buổi 4)
            if (max == null)                       // (2) danh sách rỗng
                AddFirst(nodeX);
            else
                InsertXBeforeY(nodeX, max);        // (3) tái sử dụng InsertXBeforeY
        }
        public void RShiftRight()
        {
            if (IsEmpty() || first == last)        // (1) rỗng hoặc 1 node: xoay xong vẫn như cũ
                return;

            IntNode pLast = new IntNode(last.Data); // (2) giữ lại bản sao của node cuối
            RemoveX(last);                         // (3) xóa node cuối khỏi danh sách
            AddFirst(pLast);                       // (4) đưa bản sao lên đầu danh sách
        }
        // Sắp xếp TĂNG DẦN bằng Interchange Sort (hoán đổi data giữa các node).
        public void InterchangeSort()
        {
            for (IntNode p = first; p != null; p = p.Next)          // (1) p: vị trí đang "chốt"
            {
                for (IntNode q = p.Next; q != null; q = q.Next)      // (2) q: các node đứng sau p
                {
                    if (p.Data > q.Data)                             // (3) sai thứ tự (p lớn hơn q)
                    {
                        int tmp = p.Data;                            //     hoán đổi data của p và q
                        p.Data = q.Data;
                        q.Data = tmp;
                    }
                }
            }
        }
        public void SelectionSort()
        {
            for (IntNode p = first; p != null; p = p.Next)          // (1) p: vị trí cần đặt số lớn nhất
            {
                IntNode max = p;                                     // (2) tạm coi p là node lớn nhất
                for (IntNode q = p.Next; q != null; q = q.Next)      //     cho q là node đứng sau
                {
                    if (q.Data > max.Data)                           // (3) gặp node lớn hơn: ghi nhớ lại
                        max = q;
                }
                int tmp = p.Data;                                    // (4) hoán đổi data của p và max
                p.Data = max.Data;                                   //     (mỗi vòng ngoài chỉ đổi 1 lần)
                max.Data = tmp;
            }
        }
        // Trộn 2 danh sách đã tăng dần thành list3 cũng tăng dần (không sắp xếp lại).
        public static MyList MergeList(MyList list1, MyList list2)
        {
            MyList list3 = new MyList();
            IntNode p = list1.First;                  // (1) p chạy trên list1
            IntNode q = list2.First;                  //     q chạy trên list2

            while (p != null && q != null)            // (2) cả 2 danh sách còn node
            {
                if (p.Data <= q.Data)                 // (3) lấy node NHỎ HƠN gắn vào cuối list3
                {
                    list3.AddLast(new IntNode(p.Data));
                    p = p.Next;
                }
                else
                {
                    list3.AddLast(new IntNode(q.Data));
                    q = q.Next;
                }
            }

            while (p != null)                         // (4) list2 hết: chép nốt phần còn lại của list1
            {
                list3.AddLast(new IntNode(p.Data));
                p = p.Next;
            }

            while (q != null)                         //     list1 hết: chép nốt phần còn lại của list2
            {
                list3.AddLast(new IntNode(q.Data));
                q = q.Next;
            }

            return list3;
        }
    }
}
