using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PR_6
{
    /// <summary>
    /// Класс работает с шифрование и дешифровкой обьектов методом RSA
    /// </summary>
    public class EncryptRSA
    {
        static long c, exit, eilerFunction, e, d, n;//Переменные для работы с шифрованием 
        static public List<string> encryptFileName = new List<string>();//Пути до зашифрованных файлов

        /// <summary>
        /// Возвращает простое число в диопазоне переданных чисел
        /// </summary>
        /// <param name="min">Минимальное допустимое число</param>
        /// <param name="max">Максимальное допустимое число</param>
        /// <returns>int</returns>
        public static int GetSimpleNumber(int min, int max)
        {
            int number;
            do
            {
                number = new Random().Next(min, max + 1);

            } while (!CheckingForSimplicity(number));

            return number;
        }

        /// <summary>
        /// Расчитывает число e для открытого ключа 
        /// </summary>
        /// <param name="eilerFunction">Функция Эйлера</param>
        /// <returns>long</returns>
        public static void Calculate_e()
        {
            long e = eilerFunction - 1;

            for (long i = 2; i <= eilerFunction; i++)
            {
                if (eilerFunction % i == 0 && e % i == 0)
                {
                    e--;
                }
            }
            EncryptRSA.e = e;
        }

        /// <summary>
        /// Расчитывает число d для закрытого ключа
        /// </summary>
        /// <param name="e">Число e</param>
        /// <param name="eilerFunction">Функция Эйлера</param>
        /// <returns>long</returns>
        public static void Calculate_d()
        {
            long d = 10;
            while (true)
            {
                if ((d * e) % eilerFunction == 1 && d != e)
                    break;
                else
                    d++;
            }
            EncryptRSA.d = d;
        }

        /// <summary>
        /// Проверяет число на простоту, если число простое вернет true
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns>bool</returns>
        public static bool CheckingForSimplicity(long number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            for (long i = 2; i < number; i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Находит два случайных неравных простых чисел в диапозоне
        /// </summary>
        /// <param name="min">Мин. диапозон поиска простого числа (включительно)</param>
        /// <param name="max">Макс. диапозон поиска простого числа (включительно)</param>
        public static void GetPartOfKeys(int min, int max)
        {
            long buffer;
            long p;
            long q;

            do
            {
                p = GetSimpleNumber(min, max);
                do
                {
                    q = GetSimpleNumber(min, max);
                } while (q == p);
                buffer = p * q;
            } while (buffer < 65 || buffer > 250);

            GetResultOfSimpleNumbers(p, q);
        }

        /// <summary>
        /// Высчитывает функцию Эйлера и произвдение двух простых чисел
        /// </summary>
        /// <param name="firstOpenKey">Первое простое число</param>
        /// <param name="secondOpenKey">Второе простое число</param>
        public static void GetResultOfSimpleNumbers(long firstOpenKey, long secondOpenKey)
        {
            n = firstOpenKey * secondOpenKey;
            eilerFunction = (firstOpenKey - 1) * (secondOpenKey - 1);
        }

        /// <summary>
        /// Делит байты по блокам в 64 для шифрования методом RSA
        /// </summary>
        /// <param name="byteArray">Массив байтов файла</param>
        /// <returns>Массив байтов файла разделенный по блокам в 64</returns>
        public static byte[] CovertBytesToRSA(byte[] byteArray)
        {
            byte[] buffer = new byte[byteArray.Length * 4];
            byte oneByte;

            for (int i = 0, j = 0; i < byteArray.Length; i++)
            {
                oneByte = byteArray[i];

                for (int k = 0; k < 4; k++)
                {
                    if (oneByte > 64)
                    {
                        buffer[j] = 64;
                        oneByte -= 64;
                    }
                    else
                    {
                        buffer[j] = oneByte;
                        oneByte = 0;
                    }
                    j++;
                }
            }

            return buffer;
        }

        /// <summary>
        /// Возвращает прежнее значение байтов из блока 64
        /// </summary>
        /// <param name="byteArray">Массив байтов файла с блоком в 64</param>
        /// <returns>Массив байтов файла</returns>
        public static byte[] CovertBytesFromRSA(byte[] byteArray)
        {
            byte[] buffer = new byte[byteArray.Length / 4];

            for (int i = 0, j = 0; i < byteArray.Length; i += 4, j++)
            {
                buffer[j] = (byte)(byteArray[i] + byteArray[i + 1] + byteArray[i + 2] + byteArray[i + 3]);
            }

            return buffer;
        }

        /// <summary>
        /// Шифрует выбранные пользователем файлы методом RSA в указанный путь
        /// </summary>
        /// <param name="middlePath">Путь, куда нужно зашифровать файлы</param>
        public static void EncryptAnFiles(string middlePath)
        {
            encryptFileName.Clear();

            foreach (string file in ListViewWorker.filesName)
            {
                FileInfo fileInfo = new FileInfo(file);
                byte[] byteCodeFile = CovertBytesToRSA(File.ReadAllBytes(file));

                for (int i = 0; i < byteCodeFile.Length; i++)
                {
                    c = 1;
                    exit = 0;

                    while (exit < e)
                    {
                        exit++;
                        c = (byteCodeFile[i] * c) % n;
                    }

                    byteCodeFile[i] = (byte)c;
                }
                File.WriteAllBytes(middlePath + fileInfo.Name, byteCodeFile);
                encryptFileName.Add(middlePath + fileInfo.Name);
            }
        }

        /// <summary>
        /// Шифрует файлы, которые пользователь добавляет в существующий архив
        /// </summary>
        /// <param name="middlePath">Промежуточный путь(указывайте путь до директории архива(без имени архива!))</param>
        /// <param name="fileName">Полный путь до добавляемого файла файла</param>
        public static void EncryptAnFilesAddedToArchive(string middlePath, string fileName)
        {
            encryptFileName.Clear();

            FileInfo fileInfo = new FileInfo(fileName);
            byte[] byteCodeFile = CovertBytesToRSA(File.ReadAllBytes(fileName));

            for (int i = 0; i < byteCodeFile.Length; i++)
            {
                c = 1;
                exit = 0;

                while (exit < e)
                {
                    exit++;
                    c = (byteCodeFile[i] * c) % n;
                }

                byteCodeFile[i] = (byte)c;
            }
            File.WriteAllBytes(middlePath + fileInfo.Name, byteCodeFile);
            encryptFileName.Add(middlePath + fileInfo.Name);
        }

        /// <summary>
        /// Расшифровывает файлы
        /// </summary>
        /// <param name="encryptFilesName">Передаем массив с именами нужных к расшифровке файлов</param>
        public static void DecryptAnFiles(string[] encryptFilesName)
        {
            foreach (string file in encryptFilesName)
            {
                byte[] byteCodeFile = File.ReadAllBytes(file);

                for (int i = 0; i < byteCodeFile.Length; i++)
                {
                    c = 1;
                    exit = 0;

                    while (exit < d)
                    {
                        exit++;
                        c = (byteCodeFile[i] * c) % n;
                    }

                    byteCodeFile[i] = (byte)c;
                }
                byteCodeFile = CovertBytesFromRSA(byteCodeFile);
                File.WriteAllBytes(file, byteCodeFile);
            }
        }

    }
}
