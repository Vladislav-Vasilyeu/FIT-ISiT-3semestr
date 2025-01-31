using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class VVVLog
    {
        private readonly string _logFilePath;

        public VVVLog(string logFilePath = "vvvlogfile.txt")
        {
            _logFilePath = logFilePath;
        }
        public void WriteLog(string action, string details)
        {
            string logEntry = $"{DateTime.Now:G} | Action: {action} | Details: {details}";
            try
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }
        public string ReadLog()
        {
            try
            {
                return File.ReadAllText(_logFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return string.Empty;
            }
        }
        public string SearchInLog(string keyword)
        {
            try
            {
                var lines = File.ReadAllLines(_logFilePath);
                var matchingLines = string.Join(Environment.NewLine, Array.FindAll(lines, line => line.Contains(keyword)));
                return string.IsNullOrEmpty(matchingLines) ? "Нет совпадений." : matchingLines;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске в файле: {ex.Message}");
                return string.Empty;
            }
        }
        public static void SearchByKeyword(string logFilePath, string keyword)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                using (StreamReader reader = new StreamReader(logFilePath))
                {
                    string line;
                    bool found = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(keyword))
                        {
                            Console.WriteLine(line);
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Записи с ключевым словом '{keyword}' не найдены.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске: {ex.Message}");
            }
        }
        public static void SearchByDateRange(string logFilePath, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                using (StreamReader reader = new StreamReader(logFilePath))
                {
                    string line;
                    bool found = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (DateTime.TryParse(line.Substring(0, 19), out DateTime logDate) && logDate >= startDate && logDate <= endDate)
                        {
                            Console.WriteLine(line);
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Записи за период с {startDate} по {endDate} не найдены.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске: {ex.Message}");
            }
        }
        public static int CountLogEntries(string logFilePath)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return 0;
                }

                int count = 0;

                using (StreamReader reader = new StreamReader(logFilePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"Количество записей в файле: {count}");
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при подсчете записей: {ex.Message}");
                return 0;
            }
        }
        public static void DeleteOldEntries(string logFilePath)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                DateTime currentHour = DateTime.Now;
                DateTime startOfCurrentHour = new DateTime(currentHour.Year, currentHour.Month, currentHour.Day, currentHour.Hour, 0, 0);

                var lines = File.ReadAllLines(logFilePath)
                    .Where(line => DateTime.TryParse(line.Substring(0, 19), out DateTime logDate) && logDate >= startOfCurrentHour)
                    .ToList();

                // Перезаписываем файл только с записями за текущий час
                File.WriteAllLines(logFilePath, lines);

                Console.WriteLine("Все записи, кроме текущего часа, были удалены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении записей: {ex.Message}");
            }
        }
    }



    public class VVVDiskInfo
    {
        public static void ShowFreeSpace(string driveName)
        {
            try
            {
                var drive = new DriveInfo(driveName);
                if (drive.IsReady)
                {
                    Console.WriteLine($"Диск: {drive.Name}");
                    Console.WriteLine($"Свободное место: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
                }
                else
                {
                    Console.WriteLine($"Диск {driveName} недоступен.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowFileSystemInfo(string driveName)
        {
            try
            {
                var drive = new DriveInfo(driveName);
                if (drive.IsReady)
                {
                    Console.WriteLine($"Диск: {drive.Name}");
                    Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                }
                else
                {
                    Console.WriteLine($"Диск {driveName} недоступен.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowAllDrivesInfo()
        {
            try
            {
                var drives = DriveInfo.GetDrives();
                foreach (var drive in drives)
                {
                    Console.WriteLine($"Диск: {drive.Name}");
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Объем: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ");
                        Console.WriteLine($"Доступный объем: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
                        Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                        Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                    }
                    else
                    {
                        Console.WriteLine("Диск недоступен.");
                    }
                    Console.WriteLine(new string('-', 30));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }



    public class VVVFileInfo
    {
        
        public static void ShowFullPath(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"Полный путь: {file.FullName}");
                }
                else
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowBasicInfo(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"Имя файла: {file.Name}");
                    Console.WriteLine($"Расширение: {file.Extension}");
                    Console.WriteLine($"Размер: {file.Length / 1024.0:F2} КБ");
                }
                else
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowDateInfo(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Console.WriteLine($"Дата создания: {file.CreationTime}");
                    Console.WriteLine($"Дата последнего изменения: {file.LastWriteTime}");
                }
                else
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }



    public class VVVDirInfo
    {
        public static void ShowFileCount(string dirPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    int fileCount = dir.GetFiles().Length;
                    Console.WriteLine($"Количество файлов: {fileCount}");
                }
                else
                {
                    Console.WriteLine($"Директория {dirPath} не найдена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowCreationTime(string dirPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine($"Время создания: {dir.CreationTime}");
                }
                else
                {
                    Console.WriteLine($"Директория {dirPath} не найдена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowSubdirectoryCount(string dirPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    int subDirCount = dir.GetDirectories().Length;
                    Console.WriteLine($"Количество поддиректориев: {subDirCount}");
                }
                else
                {
                    Console.WriteLine($"Директория {dirPath} не найдена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ShowParentDirectories(string dirPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (dir.Exists)
                {
                    Console.WriteLine("Родительские директории:");
                    DirectoryInfo parent = dir.Parent;
                    while (parent != null)
                    {
                        Console.WriteLine($"- {parent.FullName}");
                        parent = parent.Parent;
                    }
                }
                else
                {
                    Console.WriteLine($"Директория {dirPath} не найдена.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }



    public class VVVFileManager
    {
        public static void InspectDirectory(string driveName)
        {
            string inspectDirPath = "VVVInspect";
            string filePath = Path.Combine(inspectDirPath, "VVVdirinfo.txt");

            try
            {
                if (!Directory.Exists(inspectDirPath))
                {
                    Directory.CreateDirectory(inspectDirPath);
                }

                var driveInfo = new DirectoryInfo(driveName);
                if (!driveInfo.Exists)
                {
                    Console.WriteLine($"Диск или директория {driveName} не найдена.");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Список файлов:");
                    foreach (var file in driveInfo.GetFiles())
                    {
                        writer.WriteLine($"- {file.Name}");
                    }

                    writer.WriteLine("\nСписок папок:");
                    foreach (var dir in driveInfo.GetDirectories())
                    {
                        writer.WriteLine($"- {dir.Name}");
                    }
                }

                string copyPath = Path.Combine(inspectDirPath, "VVVdirinfo_copy.txt");
                File.Copy(filePath, copyPath, true);
                File.Delete(filePath);
                Console.WriteLine($"Информация сохранена и копия создана: {copyPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void CopyFilesByExtension(string sourceDir, string extension, string targetDir)
        {
            try
            {
                if (!Directory.Exists(sourceDir))
                {
                    Console.WriteLine($"Директория {sourceDir} не найдена.");
                    return;
                }

                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                var files = Directory.GetFiles(sourceDir, $"*{extension}");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string targetPath = Path.Combine(targetDir, fileName);
                    File.Copy(file, targetPath, true);
                }

                Console.WriteLine($"Файлы с расширением {extension} скопированы в {targetDir}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void MoveDirectory(string sourceDir, string targetDir)
        {
            try
            {
                if (!Directory.Exists(sourceDir))
                {
                    Console.WriteLine($"Директория {sourceDir} не найдена.");
                    return;
                }

                string targetPath = Path.Combine(targetDir, Path.GetFileName(sourceDir));
                if (Directory.Exists(targetPath))
                {
                    Directory.Delete(targetPath, true);
                }

                Directory.Move(sourceDir, targetPath);
                Console.WriteLine($"Директория {sourceDir} перемещена в {targetPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ArchiveDirectory(string sourceDir, string archivePath)
        {
            try
            {
                if (!Directory.Exists(sourceDir))
                {
                    Console.WriteLine($"Директория {sourceDir} не найдена.");
                    return;
                }

                if (File.Exists(archivePath))
                {
                    File.Delete(archivePath);
                }

                ZipFile.CreateFromDirectory(sourceDir, archivePath);
                Console.WriteLine($"Директория {sourceDir} заархивирована в {archivePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static void ExtractArchive(string archivePath, string extractPath)
        {
            try
            {
                if (!File.Exists(archivePath))
                {
                    Console.WriteLine($"Архив {archivePath} не найден.");
                    return;
                }

                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                ZipFile.ExtractToDirectory(archivePath, extractPath);
                Console.WriteLine($"Архив {archivePath} разархивирован в {extractPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            VVVLog log = new VVVLog("test_log.txt");

            log.WriteLog("TestAction", "This is a test log entry.");

            string logContents = log.ReadLog();
            Console.WriteLine("Log contents:");
            Console.WriteLine(logContents);

            string searchResult = log.SearchInLog("TestAction");
            Console.WriteLine("Search result:");
            Console.WriteLine(searchResult);

            int logCount = VVVLog.CountLogEntries("test_log.txt");

            VVVLog.DeleteOldEntries("test_log.txt");

            VVVDiskInfo.ShowFreeSpace("C:");
            VVVDiskInfo.ShowFileSystemInfo("C:");
            VVVDiskInfo.ShowAllDrivesInfo();

            VVVFileInfo.ShowFullPath("test_log.txt");
            VVVFileInfo.ShowBasicInfo("test_log.txt");
            VVVFileInfo.ShowDateInfo("test_log.txt");

            VVVDirInfo.ShowFileCount("C:\\");
            VVVDirInfo.ShowCreationTime("C:\\");
            VVVDirInfo.ShowSubdirectoryCount("C:\\");
            VVVDirInfo.ShowParentDirectories("C:\\");

            VVVFileManager.InspectDirectory("C:\\");
            VVVFileManager.CopyFilesByExtension("C:\\", ".txt", "C:\\VVVFiles");
            VVVFileManager.MoveDirectory("C:\\VVVFiles", "C:\\VVVFiles_Moved");
            VVVFileManager.ArchiveDirectory("C:\\VVVFiles_Moved", "C:\\VVVFiles_Moved.zip");
            VVVFileManager.ExtractArchive("C:\\VVVFiles_Moved.zip", "C:\\VVVFiles_Moved_Extracted");

            Console.WriteLine("Тестирование завершено.");
        }
    }

}
