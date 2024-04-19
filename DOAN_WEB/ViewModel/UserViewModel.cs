using DOAN_WEB.Models;

namespace DOAN_WEB.ViewModel
{
    public class UserViewModel
    {
        public List<User>? User { get; set; }
        public List<ChucVu>? ChucVu { get; set; }
        public User Register { get; set; }
        public UserViewModel()
        {
            Register = new User();
        }
        public virtual ChucVu MaCvNavigation { get; set; }
    }
}
