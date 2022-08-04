
//mahdi mollaeian comment

try
{
    //var r1 = m1();
    //Console.WriteLine("result = " + r1);

    var r2 = m2();
    Console.WriteLine("result = " + r2);
}
catch (ArgumentException ex)
{
    Console.WriteLine(" ----------- ArgumentException - catch -----------------");
    Console.WriteLine("Error with parameters --- " + ex.Message);
}
catch (Exception ex)
{
    // log to database
    // send an alert
    // a good message

    Console.WriteLine(" ----------- main - catch -----------------");
    
    Console.WriteLine(" ---------- Message -----------------");
    Console.WriteLine(ex.Message);

    Console.WriteLine(" ---------- StackTrace -----------------");
    Console.WriteLine(ex.StackTrace);

    var inner = ex.InnerException;
    while (inner != null)
    {

        Console.WriteLine(" ---------- InnerException.Message -----------------");
        Console.WriteLine(ex.InnerException.Message);
        Console.WriteLine(" ---------- InnerException.StackTrace -----------------");
        Console.WriteLine(ex.InnerException.StackTrace);
        inner = inner.InnerException;
    }

    // throw;
}


int m1()
{
    Numbers demo = new Numbers();
    return demo.GrantParent(6, 2);
}



int m2()
{
    Numbers demo = new Numbers();
    return demo.GrantParent(5, 0);
}