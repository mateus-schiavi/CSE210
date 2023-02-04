class Memorizing
{
    private Scripture _script;
    private string[] _arguments;
    private string[] _unseenArguments;
    private Random _randomic;

    public Memorizing()
    {

    }

    public Memorizing(string[] strArguments, string[] strunseenarguments)
    {
        setScript(strArguments);
        setUnseenarguments(strunseenarguments);
        _arguments = _script.Quotation.Split("\n");
        _unseenArguments = new string[_arguments.Length];
        _randomic = new Random();
    }

    public void setScript(string[] strArguments)
    {
        this._arguments = strArguments;
    }

    public void setUnseenarguments(string[] strunseenarguments)
    {
        this._unseenArguments = strunseenarguments;
    }

    public void Begin()
    {
        FreeTable();
        ShowArgument();
        try
        {    
            while(!FullHideArgument()) 
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter to proceed or type 'exit' to close the program");
                string value = Console.ReadLine();

                if(value.ToLower() == "exit")
                break;

                MaskRandomArgs();
                FreeTable();
                ShowArgument();
            }
            if(FullHideArgument())
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press enter one more time or type 'exit' to close the program:");
                Console.ReadLine();
            }  
        }
        catch(Exception ex)
        {
            Console.WriteLine("An Error Has Occurred " + ex.Message);
        }
    }

    private void MaskRandomArgs()
    {
        try
        {
            int ResidualArgs = _unseenArguments.Count(_arguments => _arguments == null);
        
            if (ResidualArgs <= 4)
            {
                for(int k = 0; k < _unseenArguments.Length; k++)
                {
                    if(_unseenArguments[k] == null)
                    {
                        _unseenArguments[k] = new string('_', _arguments[k].Length);
                        ResidualArgs--;
                    }
                }
            }
            else
            {
                int result = _randomic.Next(1, Math.Min(ResidualArgs, ResidualArgs / 2));
                for(int w = 0; w < result; w ++)
                {
                    int connection = _randomic.Next(0, _arguments.Length);

                    if(_unseenArguments[connection] == null)
                    {
                        _unseenArguments[connection] = new string('_', _arguments[connection].Length);
                        ResidualArgs--;
                    }
                    else
                    {
                        w++;
                    }                
                }
            }            
        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Has Occured" + ex.Message);
        }
    }
    private bool FullHideArgument()
    {
        return !_unseenArguments.Contains(null);
        {
            
        }
    }

    private void ShowArgument()
    {
        try
        {
            Console.WriteLine(_script.Mention);
            Console.WriteLine();

            int CurrentSlashSize = 0;
            int MaxSlashSize = Console.WindowWidth - 8;

            for(int z = 0; z < _arguments.Length; z ++)
            {
                string _speech = _unseenArguments[z] != null ? _unseenArguments[z] : _unseenArguments[z];
                int NextSlashSize = CurrentSlashSize + _arguments.Length + 2;

                if(NextSlashSize > MaxSlashSize)
                {
                    Console.WriteLine();
                    CurrentSlashSize = 0;
                }
                else
                {
                    Console.WriteLine("--");
                }
            }
            Console.Write(_arguments + "  ");
            CurrentSlashSize += _arguments.Length + 2;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An Error Has Occured" + ex.Message);
        }
    }
    private void FreeTable()
    {
        Console.Clear();
    }
}