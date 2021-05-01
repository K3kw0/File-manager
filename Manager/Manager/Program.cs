using System;
using System.IO;

namespace Manager
{
    class Program
    {
        static void Info(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string s = dirs[i];
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }   // вывод каталога

        static void Rm(string let)
        {
            Console.Write("Введите папку --> ");
            string Folder = Console.ReadLine();
            try
            {
                string path = $"{let}:\\{Folder}";
                Directory.Delete(path, true);
                Console.WriteLine("deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }         // удаление папок

        static void Mv(string let)
        {
            try
            {
                Console.Write("Введите папку файлы которой хотите переместить --> ");
                string FolderOld = Console.ReadLine();
                string oldPath = $"{let}:\\{FolderOld}";
                Console.Write("Введите папку назначения (при условии что её не существует) --> ");
                string Foldenew = Console.ReadLine();
                Console.Write("Введите диск назначения --> ");
                string disck = Console.ReadLine().ToUpper();
                string newPath = $"{disck}:\\{Foldenew}";
                DirectoryInfo dir = new DirectoryInfo(oldPath);
                if (dir.Exists && Directory.Exists(newPath) == false)
                {
                    dir.MoveTo(newPath);
                }
                else Console.WriteLine("Папка в которую вы хотите переместить содерижмое не должна существовать");
            }
            catch (IOException)
            {
                Console.WriteLine("Проверьте коректность введённой информации");
            }
        }         // перемещение папки

        static void Mvf(string let)
        {
            try
            {
                Console.Write("Введите имя файла --> ");
                string namee = Console.ReadLine();
                Console.Write("Введите папку (если есть) --> ");
                string fold = Console.ReadLine();
                string path = $"{let}:\\{fold}\\{namee}";
                Console.Write("Введите папку назначения --> ");
                string fold2 = Console.ReadLine();
                string newPath = $"{let}:\\{fold2}\\{namee}";
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.MoveTo(newPath);
                }
                else Console.WriteLine("Проверьте коректность введённой информации");
            }
            catch (IOException)
            {
                Console.WriteLine("Проверьте коректность введённой информации");
            }
        }        // перемещение файлов

        static void Rmf(string let)
        {
            try
            {
                Console.Write("Введите папку (если есть) --> ");
                string fold = Console.ReadLine();
                Console.Write("Введите имя файла --> ");
                string namee = Console.ReadLine();
                string path = $"{let}:\\{fold}\\{namee}";
                FileInfo del = new FileInfo(path);
                if (del.Exists)
                {
                    del.Delete();
                }
                else Console.WriteLine("Проверьте коректность введённой информации");
                Console.WriteLine("deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        // удаление файлов

        static void Inf(string let)
        {
            try
            {
                Console.Write("Введите папку (если есть) --> ");
                string fold = Console.ReadLine();
                Console.Write("Введите имя файла --> ");
                string nnamee = Console.ReadLine();
                string path = $"{let}:\\{fold}\\{nnamee}";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine($"Имя файла --> {fileInf.Name}");
                    Console.WriteLine($"Время создания --> {fileInf.CreationTime}");
                    Console.WriteLine($"Размер --> {fileInf.Length}");
                }
                else Console.WriteLine("Введите парвильное имя файла");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        // вывод информации о файле

        static void Cpf(string let)
        {
            try
            {
                Console.Write("Введите имя файла --> ");
                string namee = Console.ReadLine();
                Console.Write("Введите папку (если есть) --> ");
                string fold = Console.ReadLine();
                string path = $"{let}:\\{fold}\\{namee}";
                Console.Write("Введите папку назначения --> ");
                string fold2 = Console.ReadLine();
                string newPath = $"{let}:\\{fold2}\\{namee}";
                FileInfo ff = new FileInfo(path);
                if (ff.Exists)
                {
                    ff.CopyTo(newPath, true);
                }
                else Console.WriteLine("Проверьте коректность введённой информации");
            }
            catch (IOException)
            {
                Console.WriteLine("Проверьте коректность введённой информации");
            }
        }        // копирование файла

        static void Cp(string let)
        {
            Console.Write("Введите папку (если есть) --> ");
            string fold = Console.ReadLine();
            string path = $"{let}:\\{fold}";
            Console.Write("Введите папку назначения --> ");
            string fold2 = Console.ReadLine();
            string newPath = $"{let}:\\{fold2}";
            foreach (string dirPath in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(path, newPath));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (string NewPath in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(NewPath, NewPath.Replace(path, newPath), true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }         // копирование папки

        static void NewDisck(string w, string q, string let)
        {
            string move;
            do
            {
                move = Console.ReadLine();
                switch (move)
                {
                    case "ls":
                        Info(w);
                        break;

                    case "cd":
                        Console.Write("Введите папку --> ");
                        string folderr = Console.ReadLine();
                        Info($"{q}:\\{folderr}");
                        break;

                    case "rm":
                        Rm(q);
                        break;

                    case "mv":
                        Mv(q);
                        break;

                    case "mvf":
                        Mvf(q);
                        break;

                    case "rmf":
                        Rmf(q);
                        break;

                    case "inf":
                        Inf(q);
                        break;

                    case "cpf":
                        Cpf(q);
                        break;

                    case "cp":
                        Cp(q);
                        break;

                    default:
                        Console.WriteLine($"{let}:\\");
                        break;
                }
            } while (move != @"\\");
        }   // метод используемый для работы при выборе нового диска

        static void Main(string[] args)
        {
            Console.WriteLine("Для получения списков возможных действий введите help.");
            Console.WriteLine("Существующие диски: ");
            string[] Drives = Environment.GetLogicalDrives();
            for (int i = 0; i < Drives.Length; i++)
            {
                string s = Drives[i];
                Console.WriteLine(s);
            }
            Console.Write("Введите букву диска с которым хотите работать --> ");
            string let = Console.ReadLine().ToUpper();
            string dirName = $"{let}:\\";
            string name;
            do
            {
                name = Console.ReadLine();
                switch (name)
                {
                    case "help":
                        Console.WriteLine("ls - выводит список файлов\\папок в каталоге" +
                            "\ncd - выводит список файлов\\папок в указанной папке" +
                            "\ncd\\ - выбор другого диска" +
                            "\n\\\\ - возврат к первому диску" +
                            "\nrm - удаление папки" +
                            "\nmv - перемещение папки" +
                            "\nmvf - перемещение файла" +
                            "\nrmf - удаление файла" +
                            "\ninf - информация о файле" +
                            "\ncp - копирование папки" +
                            "\ncpf - копирование файла" +
                            "\nвыход - завершение работы");
                        break;

                    case "ls":
                        Info(dirName);
                        break;

                    case "cd":
                        Console.Write("Введите папку --> ");
                        string folder = Console.ReadLine();
                        Info($"{let}:\\{folder}");
                        break;

                    case @"cd\":
                        Console.WriteLine("Существующие диски: ");
                        string[] f = Environment.GetLogicalDrives();
                        for (int i = 0; i < f.Length; i++)
                        {
                            string s = Drives[i];
                            Console.WriteLine(s);
                        }
                        Console.Write("Введите букву диска с которым хотите работать --> ");
                        string q = Console.ReadLine().ToUpper();
                        string w = $"{q}:\\";
                        NewDisck(w, q, let);
                        break;

                    case "rm":
                        Rm(let);
                        break;

                    case "mv":
                        Mv(let);
                        break;

                    case "mvf":
                        Mvf(let);
                        break;

                    case "rmf":
                        Rmf(let);
                        break;

                    case "inf":
                        Inf(let);
                        break;

                    case "cpf":
                        Cpf(let);
                        break;

                    case "cp":
                        Cp(let);
                        break;

                    default: Console.WriteLine("Команда введена не верно."); break;
                }
            } while (name != "выход");
        }
    }
}


