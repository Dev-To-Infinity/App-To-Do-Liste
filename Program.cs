using ConsoleApp2;
using Task = ConsoleApp2.Task;

string path = @"C:\\Users\\jakow\\Documents\\WriteLines.txt";
bool result = File.Exists(path);

var tasklist = new List<Task>();
string enteredValue;

void manageLoadList()
{
    while (tasklist.Count != 0)
    {
        tasklist.RemoveAt(0);
    }

    string nameOfTask = null;
    string deadline = null;
    string[] strings = System.IO.File.ReadAllLines(@"C:\Users\jakow\Documents\WriteLines.txt");
    var tasknames = new List<string>();
    int wordIndex = 0;
    int saveWordsCounter = 0;
    int fuseindex = 0;

    foreach (string str in strings)
    {
        string[] words = str.Split(' ');
        int wordsCounter = 0;
        nameOfTask = null;
        while (words[wordsCounter] != "|")
        {
            string word = words[wordsCounter];
            if (nameOfTask == null)
            {
                nameOfTask = word;
            }
            else
            {
                nameOfTask += $" {word}";
            }
            wordsCounter++;
        }
        tasknames.Add(nameOfTask);
    }

    for (int i = 0; i < tasknames.Count; i++)
    {
        tasklist.Add(new Task(tasknames[wordIndex]));
        wordIndex++;
    }

    foreach (string str in strings)
    {
        string[] words = str.Split(' ');
        int wordsCounter = 0;
        while (words[wordsCounter] != "|")
        {
            wordsCounter++;
        }
        saveWordsCounter = wordsCounter++;
    }

    foreach (string str in strings)
    {
        int wordsCounter = saveWordsCounter;
        string[] words = str.Split(' ');
        while (words[wordsCounter] != "|")
        {
            string word = words[wordsCounter];
            if (deadline == null)
            {
                deadline = word;
            }
            else
            {
                deadline += $" {word}";
            }
            wordsCounter++;
        }
        tasklist[fuseindex].Deadline = deadline;
        fuseindex++;
    }
    fuseindex = 0;

    foreach (string str in strings)
    {
        if (str.EndsWith("True"))
        {
            tasklist[fuseindex].Checkmark = true;
        }
        else if (str.EndsWith("False"))
        {
            tasklist[fuseindex].Checkmark = false;
        }
        fuseindex++;
    }
    Console.WriteLine("");
    Console.WriteLine("List loaded.");
    Console.WriteLine("");
}

void manageList()
{
    foreach (Task task in tasklist)
    {
        string checkmarkStatus;
        if (task.Checkmark == true)
        {
            checkmarkStatus = "finished";
        }
        else
        {
            checkmarkStatus = "not finished";
        }
        Console.WriteLine("");
        Console.WriteLine($"{tasklist.IndexOf(task) + 1}. {task.Name}     | Deadline: {task.Deadline}     | {checkmarkStatus}");
    }
    Console.WriteLine("");
}

void menu()
{
    Console.WriteLine("If you want to add a task, type in: mAdd.");
    Console.WriteLine("If you want to list your task, type in: mList");
    Console.WriteLine("If you want to check your task, type in: mCheck");
    Console.WriteLine("If you want to remove a task's check, type in: mRemoveCheck");
    Console.WriteLine("If you want to add a deadline, type in: mDeadline");
    Console.WriteLine("If you want to delete a single task, type in: mDelete");
    Console.WriteLine("If you want to clear your list, type in: mClear");
    Console.WriteLine("If you want to clear the console, type in: mCC");
    Console.WriteLine("If you want to save the changes on your list, type in: mSave");
    Console.WriteLine("If you want to load your saved list, type in: mLoad");
    Console.WriteLine("If you want to close your list, type in: q");
    Console.WriteLine("");
}

void manageCheck()
{
    manageList();
    Console.WriteLine("Which tasknumber did you finish?");
    Console.WriteLine("");
    int taskindex = Int32.Parse(Console.ReadLine());
    tasklist[taskindex - 1].Checkmark = true;
    Console.WriteLine("");
    Console.WriteLine("Task is now marked as finished.");
    Console.WriteLine("");
}

void manageRemoveCheck()
{
    manageList();
    Console.WriteLine("Which tasknumber's check would you like to delete?");
    Console.WriteLine("");
    int taskindex = Int32.Parse(Console.ReadLine());
    tasklist[taskindex - 1].Checkmark = false;
    Console.WriteLine("");
    Console.WriteLine("The task's check has been removed.");
    Console.WriteLine("");
}

void manageDeadline()
{
    manageList();
    Console.WriteLine("Which tasknumber would you like to add a deadline?");
    Console.WriteLine("");
    string enteredValue = Console.ReadLine();
    int taskindex = Int32.Parse(enteredValue) - 1;
    Console.WriteLine("");
    Console.WriteLine("Please enter the date without using spaces.");
    Console.WriteLine("");
    enteredValue = Console.ReadLine();
    Console.WriteLine("");
    Console.WriteLine("Please enter the time without using spaces.");
    Console.WriteLine("");
    enteredValue += $" {Console.ReadLine()}";
    tasklist[taskindex].Deadline = enteredValue;
    Console.WriteLine("");
    Console.WriteLine("The task's deadline has been changed.");
    Console.WriteLine("");
}

void manageDelete()
{
    manageList();
    Console.WriteLine("Which tasknumber would you like to delete?");
    Console.WriteLine("");
    int deleteNumber = Int32.Parse(Console.ReadLine()) - 1;
    tasklist.RemoveAt(deleteNumber);
    Console.WriteLine("");
    Console.WriteLine("Task deleted.");
    Console.WriteLine("");
}

void manageClearList()
{
    while (tasklist.Count != 0)
    {
        tasklist.RemoveAt(0);
    }
    Console.WriteLine("");
    Console.WriteLine("Your list is now empty");
    Console.WriteLine("");
}

void manageAdd()
{
    Console.WriteLine("");
    Console.WriteLine("How would you like to name the task?");
    Console.WriteLine("");
    string taskname = Console.ReadLine();
    tasklist.Add(new Task(taskname));
    Console.WriteLine("");
    Console.WriteLine("Task is now added");
    Console.WriteLine("");
}

void manageSave()
{
    var strings = new List<string>();
    foreach (Task task in tasklist)
    {
        strings.Add($"{task.Name} | {task.Deadline} | {task.Checkmark}");
    }
    File.WriteAllLines(@"C:\Users\jakow\Documents\WriteLines.txt", strings);
    Console.WriteLine("");
    Console.WriteLine("Your list is now saved.");
    Console.WriteLine("");
}

Console.WriteLine("Welcome to ToDoList.");
Console.WriteLine("");

if (result == true)
{
    manageLoadList();
}

do
{
    menu();
    enteredValue = Console.ReadLine();


    if (enteredValue == "mCheck")
    {
        manageCheck();
    }
    else if (enteredValue == "mRemoveCheck")
    {
        manageRemoveCheck();
    }
    else if (enteredValue == "mDeadline")
    {
        manageDeadline();
    }
    else if (enteredValue == "mList")
    {
        manageList();
    }
    else if (enteredValue == "mDelete")
    {
        manageDelete();
    }
    else if (enteredValue == "mClear")
    {
        manageClearList();
    }
    else if (enteredValue == "mCC")
    {
        Console.Clear();
    }
    else if (enteredValue == "mSave")
    {
        manageSave();
    }
    else if (enteredValue == "mLoad")
    {
        manageLoadList();
    }
    else if (enteredValue == "mAdd")
    {
        manageAdd();
    }
} while (enteredValue != "q");