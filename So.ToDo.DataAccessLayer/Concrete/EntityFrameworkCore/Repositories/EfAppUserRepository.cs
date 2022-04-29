using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetUsersNotInAdminRole()
        {
            using var context = new ToDoContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                 (resultUser, resultUserRole) => new
                 {
                     user = resultUser,
                     userRole = resultUserRole
                 }).Where(x => x.userRole.RoleId == 2).Join(context.Roles, twoTablesResult => twoTablesResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                 {
                     users = resultTable.user,
                     userRoles = resultTable.userRole,
                     roles = resultRole
                 }).Where(x => x.roles.Name == "Member").Select(x => new AppUser
                 {
                     Id = x.users.Id,
                     Name = x.users.Name,
                     Surname = x.users.Surname,
                     Email = x.users.Email,
                     Picture = x.users.Picture,
                     UserName = x.users.UserName
                 }).ToList();
        }

        public List<AppUser> GetUsersNotInAdminRole(out int totalpage, string searchword, int activepage = 1)
        {

            using var context = new ToDoContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Where(x => x.userRole.RoleId == 2).Join(context.Roles, twoTablesResult => twoTablesResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                {
                    users = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(x => x.roles.Name == "Member").Select(x => new AppUser
                {
                    Id = x.users.Id,
                    Name = x.users.Name,
                    Surname = x.users.Surname,
                    Email = x.users.Email,
                    Picture = x.users.Picture,
                    UserName = x.users.UserName
                });
            totalpage = (int)Math.Ceiling((double)result.Count() / 3);

            //brings only member users then for search bar using where
            if (!string.IsNullOrWhiteSpace(searchword))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchword) || x.Surname.ToLower().Contains(searchword.ToLower()));
                totalpage = (int)Math.Ceiling((double)result.Count() / 3);
            }
            //after all result for the pagination showing if there 3 user 
            result = result.Skip((activepage - 1) * 3).Take(3);
            return result.ToList();
        }

    }
}
