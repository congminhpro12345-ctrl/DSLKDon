using DSLKDon;
using System;

namespace DSKLDon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n------ BAI TAP 4: DSLK DON ------");
                Console.WriteLine("1. Test Input_Front + ShowList");
                Console.WriteLine("2. Test Input_Last + ShowList");
                Console.WriteLine("3. Test SearchX");
                Console.WriteLine("4. Test GetMax");
                Console.WriteLine("5. Test GetMin");
                Console.WriteLine("6. Test GetEvenList");
                Console.WriteLine("7. Test GetOddList");
                Console.WriteLine("8. Test Input_Front (Not Duplicate)");
                Console.WriteLine("9. Test Input_Last (Not Duplicate)");
                Console.WriteLine("10. Test RemoveAt_i");
                Console.WriteLine("11. Test RemoveX");
                Console.WriteLine("12. Test InsertAt(int x, int i)");
                Console.WriteLine("13. Test InsertXAfterY");
                Console.WriteLine("14. Test InsertXAfterMin");
                Console.WriteLine("15. Test ShiftLeft");
                Console.WriteLine("16. Test InsertXBeforeY");
                Console.WriteLine("17. Test InsertXBeforeMax");
                Console.WriteLine("18. Test RShiftRight");
                Console.WriteLine("19. Test InterchangeSort");
                Console.WriteLine("20. Test SelectionSort");
                Console.WriteLine("21. Test MergeList");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: TestInput_Front(); break;
                    case 2: TestInput_Last(); break;
                    case 3: TestSearchX(); break;
                    case 4: TestGetMax(); break;
                    case 5: TestGetMin(); break;
                    case 6: TestGetEvenList();
                        break;
                    case 7:
                        TestGetOddList();
                        break;
                    case 8:
                        TestInput_Front_NotDuplicate();
                        break;
                    case 9:
                        TestInput_Last_NotDuplicate();
                        break;
                    case 10:
                        TestRemoveAt_i();
                        break;
                    case 11:
                        TestRemoveX();
                        break;
                    case 12:
                        TestInsertAt();
                        break;
                    case 13:
                        TestInsertXAfterY();
                        break;
                    case 14:
                        TestInsertXAfterMin();
                        break;
                    case 15:
                        TestShiftLeft();
                        break;
                    case 16:
                        Test_InsertXBeforeY();
                        break;
                    case 17:
                        Test_InsertXBeforeMax();
                        break;
                    case 18:
                        Test_RShiftRight();
                        break;
                    case 19:
                        Test_InterchangeSort();
                        break;
                    case 20:
                        Test_SelectionSort();
                        break;
                    case 21:
                        Test_MergeList(); // (Hàm test này sẽ được viết ngay bên dưới)
                        break;
                }
            } while (choice != 0);
            static void TestInput_Front()
            {
                MyList list = new MyList();
                list.Input_Front();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();
                Console.WriteLine("Count = " + list.Count);
            }

            static void TestInput_Last()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();
                Console.WriteLine("Count = " + list.Count);
            }
            static void TestSearchX()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x can tim: ");
                int x;
                int.TryParse(Console.ReadLine(), out x);
                IntNode kq = list.SearchX(x);
                if (kq != null)
                    Console.WriteLine("Tim thay, Data = " + kq.Data);
                else
                    Console.WriteLine("Khong tim thay!");
            }
            static void TestGetMax()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                IntNode max = list.GetMax();
                if (max != null)
                    Console.WriteLine("Max = " + max.Data);
                else
                    Console.WriteLine("Danh sach rong!");
            }

            static void TestGetMin()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                IntNode min = list.GetMin();
                if (min != null)
                    Console.WriteLine("Min = " + min.Data);
                else
                    Console.WriteLine("Danh sach rong!");
            }
            static void TestGetEvenList()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Danh sach goc:");
                list.ShowList();

                MyList evenList = list.GetEvenList();
                Console.WriteLine("--- Danh sach so chan:");
                evenList.ShowList();
                Console.WriteLine("Count = " + evenList.Count);

                Console.WriteLine("--- Danh sach goc (phai khong doi):");
                list.ShowList();
            }

            static void TestGetOddList()
            {
                MyList list = new MyList();
                list.Input_Last();
                Console.WriteLine("\n--- Danh sach goc:");
                list.ShowList();

                MyList oddList = list.GetOddList();
                Console.WriteLine("--- Danh sach so le:");
                oddList.ShowList();
                Console.WriteLine("Count = " + oddList.Count);

                Console.WriteLine("--- Danh sach goc (phai khong doi):");
                list.ShowList();
            }
            static void TestInput_Front_NotDuplicate()
            {
                MyList list = new MyList();
                list.Input_Front_NotDuplicate(); // thử nhập vài giá trị trùng nhau
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();
            }

            static void TestInput_Last_NotDuplicate()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();
            }

            static void TestRemoveAt_i()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate(); // tạo danh sách để thử
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap vi tri i (can xoa): ");
                int i = int.Parse(Console.ReadLine());
                list.RemoveAt(i);

                Console.WriteLine("\n\n---DSLK sau khi xoa tai vi tri i:");
                list.ShowList(); // hiển thị SAU khi xóa
            }

            static void TestRemoveX()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can xoa): ");
                int x = int.Parse(Console.ReadLine());
                IntNode nodeX = list.SearchX(x); // tìm node chứa x trước
                if (nodeX == null)
                    Console.WriteLine("Khong tim thay {0} trong danh sach!", x);
                else
                {
                    list.RemoveX(nodeX);
                    Console.WriteLine($"\n---DSLK sau khi xoa {{x}}:");
                    list.ShowList();
                }
            }

            static void TestInsertAt()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can them): ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Nhap vi tri i: ");
                int i = int.Parse(Console.ReadLine());
                list.InsertAt(x, i);

                Console.WriteLine($"\n---DSLK sau khi them {{x}} tai vi tri {{i}}:");
                list.ShowList();
            }

            static void TestInsertXAfterY()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can them): ");
                int x = int.Parse(Console.ReadLine());
                IntNode nodeX = new IntNode(x); // node mới chứa x

                Console.Write("Nhap y: ");
                int y = int.Parse(Console.ReadLine());
                IntNode nodeY = list.SearchX(y); // node chứa y (có thể là null)
                if (nodeY == null)
                {
                    Console.WriteLine("Khong tim thay {0} trong danh sach!", y);
                    return;
                }

                list.InsertXAfterY(nodeX, nodeY);
                Console.WriteLine($"\n---DSLK sau khi them node {{x}} sau node {{y}}:");
                list.ShowList();
            }

            static void TestInsertXAfterMin()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n--- Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can them): ");
                int x = int.Parse(Console.ReadLine());
                IntNode nodeX = new IntNode(x);

                list.InsertXAfterMin(nodeX);
                Console.WriteLine($"\n---DSLK sau khi them node {{x}} sau MIN:");
                list.ShowList();
            }

            static void TestShiftLeft()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Original linked list:");
                list.ShowList();

                list.ShiftLeft();
                Console.WriteLine($"\n---DSLK - After ShiftLeft():");
                list.ShowList();
            }
            static void Test_InsertXBeforeY()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can them): ");
                int x = int.Parse(Console.ReadLine());
                IntNode nodeX = new IntNode(x);

                Console.Write("Nhap y: ");
                int y = int.Parse(Console.ReadLine());
                IntNode nodeY = list.SearchX(y);
                if (nodeY == null)
                {
                    Console.WriteLine("Khong tim thay {0} trong danh sach!", y);
                    return;
                }

                list.InsertXBeforeY(nodeX, nodeY);
                Console.WriteLine($"\n\n---DSLK sau khi them node {{x}} TRUOC node {{y}}:");
                list.ShowList();
            }

            static void Test_InsertXBeforeMax()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Integer linked list:");
                list.ShowList();

                Console.Write("Nhap x (can them): ");
                int x = int.Parse(Console.ReadLine());
                IntNode nodeX = new IntNode(x);

                list.InsertXBeforeMax(nodeX);
                Console.WriteLine($"\n\n---DSLK sau khi them node {{x}} truoc MAX:");
                list.ShowList();
            }

            static void Test_RShiftRight()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Original linked list:");
                list.ShowList();

                list.RShiftRight();
                Console.WriteLine($"\n\n---DSLK - After RShiftRight():");
                list.ShowList();
            }
            static void Test_InterchangeSort()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Original linked list:");
                list.ShowList();

                list.InterchangeSort();

                Console.WriteLine("\n\n---DSLK - sau khi sap xep InterchangeSort:");
                list.ShowList();
            }

            static void Test_SelectionSort()
            {
                MyList list = new MyList();
                list.Input_Last_NotDuplicate();
                Console.WriteLine("\n---Original linked list:");
                list.ShowList();

                list.SelectionSort();

                Console.WriteLine("\n\n---DSLK - sau khi sap xep SelectionSort:");
                list.ShowList();
            }
            static void Test_MergeList()
            {
                MyList list1 = new MyList();
                Console.WriteLine("\n--Nhap list1:");
                list1.Input_Last_NotDuplicate();
                list1.InterchangeSort();                  // (1) đảm bảo list1 đã tăng dần
                Console.WriteLine("\n---list1 (tang dan):");
                list1.ShowList();

                MyList list2 = new MyList();
                Console.WriteLine("\n--Nhap list2:");
                list2.Input_Last_NotDuplicate();
                list2.InterchangeSort();                  //      đảm bảo list2 đã tăng dần
                Console.WriteLine("\n---list2 (tang dan):");
                list2.ShowList();

                MyList list3 = MyList.MergeList(list1, list2); // (2) gọi qua tên lớp (hàm static)
                Console.WriteLine("\n\n---list3 = MergeList(list1, list2):");
                list3.ShowList();
            }

        }
    }
   
}