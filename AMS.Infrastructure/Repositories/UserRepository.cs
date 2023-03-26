
namespace AMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User> GetUserByName(string name)
        {
            var user = await  _context.Users
                .Include(u => u.UserLocations)
                .ThenInclude(u => u.Location)
                .AsNoTracking()
                .FirstAsync(u=>u.UserName == name);
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.UserLocations)
                .ThenInclude(u => u.Location)
                .FirstOrDefaultAsync(u => u.Id == id);


            return user;
        }

        public bool SaveAsync()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
          return  await _context.Users
              .Include(u => u.UserLocations)
              .ThenInclude(u => u.Location)
              .ToListAsync();
        }
    }
}
