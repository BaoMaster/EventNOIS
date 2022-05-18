
namespace Event2206.Data;


public class GlobalAppSetting
{
    public MailSettingOption MailSetting { get; set; }
    public class MailSettingOption
    {
        /// <summary>
        /// user auth email service
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password auth email service
        /// </summary>
        public string Pasword { get; set; }

        /// <summary>
        /// support system name
        /// </summary>
        public string Support_DisplayName { get; set; }

        /// <summary>
        /// support system email
        /// </summary>
        public string Support_DisplayEmail { get; set; }

        /// <summary>
        /// admin system name
        /// </summary>
        public string Admin_Name { get; set; }

        /// <summary>
        /// admin system email
        /// </summary>
        public string Admin_Emails { get; set; }

        /// <summary>
        /// smtp
        /// </summary>
        public string Smtp { get; set; }

        /// <summary>
        /// port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// list admin emails
        /// </summary>
        public string Developer_Emails { get; set; }
    }
}
