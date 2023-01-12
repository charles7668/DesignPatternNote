User user = new User();
user.PrintState();
user.Vote();
user.PrintState();
user.Vote();
user.PrintState();

interface IState
{
    void Handle();
}

class NoCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("請投票");
    }
}

class OneCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("投票已經完成");
    }
}

class TwoCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("重複投票");
    }
}

class User
{
    IState state;
    private int voteCount = 0;

    public User()
    {
        state = new NoCountState();
    }

    public void Vote()
    {
        voteCount++;
        if (voteCount == 1)
        {
            state = new OneCountState();
        }
        else
        {
            state = new TwoCountState();
        }
    }

    public void PrintState()
    {
        state.Handle();
    }
}