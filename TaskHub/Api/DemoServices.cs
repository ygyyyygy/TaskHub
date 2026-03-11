namespace Api;

public class SingletonService1 : DisposedService, IHasInstanceId
{
    public SingletonService1() : base("Singleton1") { }
}

public class SingletonService2 : DisposedService, IHasInstanceId
{
    public SingletonService2() : base("Singleton2") { }
}

public class ScopedService1 : DisposedService, IHasInstanceId
{
    public ScopedService1() : base("Scoped1") { }
}

public class ScopedService2 : DisposedService, IHasInstanceId
{
    public ScopedService2() : base("Scoped2") { }
}

public class TransientService1 : DisposedService, IHasInstanceId
{
    public TransientService1() : base("Transient1") { }
}

public class TransientService2 : DisposedService, IHasInstanceId
{
    public TransientService2() : base("Transient2") { }
}