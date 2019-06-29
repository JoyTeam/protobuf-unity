namespace E7.Protobuf
{
    /// <summary>
    /// (EXPERIMENTAL)
    /// Your game's side of `partial` may get unwieldly fast when you add more and more accessors. You may
    /// use multiple source files of the same `partial` to organize things out, but still you are locked
    /// to the same class because it is linked with protobuf's serialization and others.
    /// 
    /// Plus one more problems, all methods shows up together in intellisense. You wish you could categorize them
    /// while somehow have it able to access all of protobuf-generated properties.
    /// 
    /// With "proto modules", it is just a wrapper class that could access your protobuf data and tell it to save. That's it!
    /// It is not even serialized, it is just an interface to your original protobuf data.
    /// 
    /// Setup instances of module in your `OnConstruction()` `partial` method, then put itself in.
    /// 
    /// ```csharpproto
    /// public CurrencyModule Currency { get; private set; }
    /// partial void OnConstruction()
    /// {
    ///     Currency = new CurrencyModule(this);
    /// }
    /// ```
    /// 
    /// Then you could `saveFileInstance.Currency.____`, as a way to organize common methods together.
    /// </summary>
    /// <typeparam name="PROTO">Your protobuf generated type here.</typeparam>
    public abstract class ProtoModule<PROTO>
    {
        protected PROTO Proto { get; }
        public abstract void Save();
        public ProtoModule(PROTO proto)
        {
            this.Proto = proto;
        }
    }
}