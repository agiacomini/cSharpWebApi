using cSharpWebApi.Data.Author.Dto;
using cSharpWebApi.Data.AuthorBook.Dto;
using cSharpWebApi.Data.Book.Dto;
using cSharpWebApi.Data.Department.Dto;
using cSharpWebApi.Data.Employee.Dto;

namespace cSharpWebApi.Data
{
    public class DataUtils
    {
        public static FetchAuthor PrepareFetchAuthor(Author.Author author)
        {
            var fetchAuthor = new FetchAuthor();
            fetchAuthor.Id = author.Id;
            fetchAuthor.FirstName = author.FirstName;
            fetchAuthor.LastName = author.LastName;
            fetchAuthor.CreatedAt = author.CreatedAt;
            fetchAuthor.CreatedBy = author.CreatedBy;
            fetchAuthor.AddressId = author.AddressId;
            fetchAuthor.AuthorBooks = new List<FetchAuthorBook>();
            foreach (var item in author.AuthorBooks)
            {
                fetchAuthor.AuthorBooks.Add(new FetchAuthorBook()
                {
                    Id = item.Id,
                    AuthorId = (int)item.AuthorId,
                    BookId = (int)item.BookId,
                    Book = new FetchBook(){
                        Id = item.Book.Id,
                        Title = item.Book.Title,
                        CreatedAt = item.Book.CreatedAt,
                        UpdatedAt = item.Book.UpdatedAt,
                        CreatedBy = item.Book.CreatedBy,
                    }
                });
            }
            return fetchAuthor;
        }

        public static FetchEmployee PrepareFetchEmployee(Employee.Employee employee)
        {
            var fetchEmployee = new FetchEmployee();
            fetchEmployee.Id = employee.Id;
            fetchEmployee.FirstName = employee.FirstName;
            fetchEmployee.LastName = employee.LastName;
            fetchEmployee.AddressId = employee.AddressId;
            fetchEmployee.Address = employee.Address;
            fetchEmployee.DepartmentId = employee.DepartmentId;
            return fetchEmployee;
        }

        public static List<FetchEmployee> PrepareFetchListEmployee(List<Employee.Employee> employeeList)
        {
            List<FetchEmployee> fetchListEmployee = new List<FetchEmployee>();
            foreach (var employee in employeeList)
            {
                fetchListEmployee.Add(PrepareFetchEmployee(employee));
            }
            return fetchListEmployee;
        }

        public static FetchDepartment PrepareFetchDepartment(Department.Department department)
        {
            var fetchDepartment = new FetchDepartment();
            fetchDepartment.Id = department.Id;
            fetchDepartment.NameDepartment = department.NameDepartment;
            if (department.Employees is not null)
                fetchDepartment.Employees = PrepareFetchListEmployee(department.Employees);
            return fetchDepartment;
        }

        public static FetchBook PrepareFetchBook(Book.Book book)
        {
            var fetchBook = new FetchBook();
            fetchBook.Id = book.Id;
            fetchBook.Title = book.Title;
            fetchBook.CreatedAt = book.CreatedAt;
            fetchBook.UpdatedAt = book.UpdatedAt;
            fetchBook.CreatedBy = book.CreatedBy;
            fetchBook.UpdatedBy = book.UpdatedBy;
            foreach (var item in book.BookAuthors)
            {
                fetchBook.Authors.Add(item.AuthorId);
            }
            return fetchBook;    
        }
    }
}