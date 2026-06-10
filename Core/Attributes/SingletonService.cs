namespace FastingFriend.Core;


public class BaseServiceRegistrationAttribute : Attribute;
public class SingletonService : BaseServiceRegistrationAttribute;
public class TransientService : BaseServiceRegistrationAttribute;