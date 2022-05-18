using Event2206.Data.EF;
using Event2206.Data.Entities;
using IronBarCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Event2206.Data.Services;

public class UserService
{
    private readonly Event2206DbContext _context;
    private readonly EmailService _emailService;
    private readonly IWebHostEnvironment _environment;

    public UserService(Event2206DbContext context, IWebHostEnvironment environment, EmailService emailService)
    {
        _context = context;
        _environment = environment;
        _emailService = emailService;
    }

    public async Task<User> GetUserDetail(string userId)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
    }

    public async Task<string> SaveRecord(User user, string uri)
    {
        if (user == null)
        {
            user = new User
            {
                Address = "phu yen",
                CompanyName = "NOIS",
                Email = "nguyenthekiet2000@gmail.com",
                FullName = "Nguyen The Kiet",
                PhoneNumber = "0123456",
                Created = DateTime.Now
            };
        }
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        //generate QR code
        var path = Path.Combine(_environment.WebRootPath, "QRImage");

        var urlDetail = uri + user.Id.ToString();
        var MyQRWithLogo = QRCodeWriter.CreateQrCode(urlDetail);
        var imageName = $"{user.Id}.png";
        MyQRWithLogo.SaveAsPng(path + "/" + imageName);

        var img = uri + "/QRImage/" + imageName;
        //send mail
        string body = await EmailTemplate(img);
        await _emailService.SendEmailAsync(user.Email, "NOIS Event 22/06", body);

        return user.Id.ToString();
    }


    public async Task<string> EmailTemplate(string img)
    {

        var pathToFile = _environment.WebRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "email-template"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Template.html";
        var builder = new BodyBuilder();
        using (StreamReader SourceReader = File.OpenText(pathToFile))
        {
            builder.HtmlBody = await SourceReader.ReadToEndAsync();
        }
        var body = builder.HtmlBody.Replace("{image}", $"{img}");
        return body;
    }
}
