public class Numbers
{
    public int GrantParent(int a, int b)
    {
        Console.WriteLine("connection.open()");
        var result = 0;
        try
        {

            throw new FormatException("test format exception");

            if (b == 0)
                throw new ArgumentException("number can't divide by zero");

            result = Parent(a, b);
        }
        catch (Exception ex)
        {
            //Console.WriteLine(" ----------- Divide - catch -----------------");
            //Console.WriteLine(ex.Message);
            //Console.WriteLine(ex.StackTrace);
            throw; // new Exception("error with bad data", ex);
        }
        finally
        {
            Console.WriteLine("connection.close()");
        }
        return result;
    }


    public int Parent(int a, int b)
    {
        return Divide(a, b);
    }

    public int Divide(int a, int b)
    {
        var result = 0;

        result = a / b;

        return result;
    }
}