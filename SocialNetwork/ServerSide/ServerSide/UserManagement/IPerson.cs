
namespace ServerSide.UserManagement
{
    using System;

    public interface IPerson
    {
        string Name { get; }

        string Surname { get; }

        string Patronymcic { get; }

        DateTime BirthDate { get; }

        Gender Gender { get; }

        MaritalStatus MaritalStatus { get; }

        string University { get; }

        string School { get; }

        int Age { get; }
    }
}
