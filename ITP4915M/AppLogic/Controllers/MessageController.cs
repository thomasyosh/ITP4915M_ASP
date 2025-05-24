using ITP4915M.Data;
using ITP4915M.Data.Dto;
using System.Text;
using ITP4915M.Helpers.LogHelper;
using ITP4915M.AppLogic.Exceptions;

namespace ITP4915M.AppLogic.Controllers;

public class MessageController
{

    private readonly DataContext _db;

    private readonly Data.Repositories.Repository<Data.Entity.Message> _sendMessageTable;
    private readonly Data.Repositories.Repository<Data.Entity.Staff_Message> _receiveMessageTable;
    private readonly Data.Repositories.Repository<Data.Entity.Account> _accountTable;
    private readonly Data.Repositories.Repository<Data.Entity.Staff> _staffTable;
    private readonly Data.Repositories.UserInfoRepository userInfo;

    public MessageController(DataContext dataContext)
    {
        _db = dataContext;
        _sendMessageTable = new Data.Repositories.Repository<Data.Entity.Message>(dataContext);
        _receiveMessageTable = new Data.Repositories.Repository<Data.Entity.Staff_Message>(dataContext);
        _accountTable = new Data.Repositories.Repository<Data.Entity.Account>(dataContext);
        _staffTable = new Data.Repositories.Repository<Data.Entity.Staff>(dataContext);
        userInfo = new Data.Repositories.UserInfoRepository(dataContext);
    }

    public Models.ReceiveMessageModel GetMessage(string username, uint limit = 0)
    {

        var account = _accountTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{username}")
        ).FirstOrDefault();

        if (account is null)
        {
            throw new BadArgException("Account is not exist in database.");
        }

        var messages = _receiveMessageTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Staff_Message>($"_receiverId:{account.Id}")
        ).OrderByDescending(m => m.message.SentDate).ToList();

        // do not show error message if the limit is not valid
        if (limit != 0 && limit < messages.Count)
        {
            messages = messages.GetRange(0, (int)limit);
        }

        List<ReceiveMessageDto> messageList = new List<ReceiveMessageDto>();
        foreach (var message in messages)
        {
            if (message.Status == Data.Entity.StaffMessageStatus.Unreceived)
            {
                message.Status = Data.Entity.StaffMessageStatus.Received;
                _receiveMessageTable.Update(message);
            }
            _receiveMessageTable.Update(message);
            messageList.Add(new ReceiveMessageDto
            {
                senderName = message.message.sender.UserName,
                sentDate = message.message.SentDate.ToShortDateString(),
                content = message.message.Content,
                Title = message.message.Title,
                id = message.message.Id,
                isRead = message.Status == Data.Entity.StaffMessageStatus.Read
            });
        }
        var messageModel = new Models.ReceiveMessageModel
        {
            messageReceived = (short)messages.Count,
            messages = messageList
        };

        return messageModel;
    }

    public Models.ReceiveMessageModel GetUnReadMessage(string username)
    {

        var account = _accountTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{username}")
        ).FirstOrDefault();

        if (account is null)
        {
            throw new BadArgException("Account is not exist in database.");
        }

        var messages = _receiveMessageTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Staff_Message>($"_receiverId:{account.Id}")
        );

        List<ReceiveMessageDto> messageList = new List<ReceiveMessageDto>();
        foreach (var message in messages)
        {
            if (message.Status == Data.Entity.StaffMessageStatus.Received)
            {
                messageList.Add(new ReceiveMessageDto
                {
                    senderName = message.message.sender.UserName,
                    sentDate = message.message.SentDate.ToShortDateString(),
                    content = message.message.Content,
                    Title = message.message.Title

                });
            }
        }
        try
        {
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            throw new OperationFailException("Cannot update message status.");
        }

        Models.ReceiveMessageModel messageModel = new Models.ReceiveMessageModel
        {
            messageReceived = (short)messageList.Count,
            messages = messageList
        };

        return messageModel;
    }

    public Models.ReceiveMessageModel GetUnreceivedMessage(string username)
    {

        var account = _accountTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{username}")
        ).FirstOrDefault();

        if (account is null)
        {
            throw new BadArgException("Account is not exist in database.");
        }

        var messages = _receiveMessageTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Staff_Message>($"_receiverId:{account.Id}")
        );

        List<ReceiveMessageDto> messageList = new List<ReceiveMessageDto>();
        foreach (var message in messages)
        {
            if (message.Status == Data.Entity.StaffMessageStatus.Unreceived)
            {
                message.Status = Data.Entity.StaffMessageStatus.Received;
                _receiveMessageTable.Update(message);

                messageList.Add(new ReceiveMessageDto
                {
                    senderName = message.message.sender.UserName,
                    sentDate = message.message.SentDate.ToShortDateString(),
                    content = message.message.Content,
                    Title = message.message.Title,
                    id = message.message.Id

                });
            }
        }
        try
        {
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            throw new OperationFailException("Cannot update message status.");
        }

        Models.ReceiveMessageModel messageModel = new Models.ReceiveMessageModel
        {
            messageReceived = (short)messageList.Count,
            messages = messageList
        };

        return messageModel;
    }

    public void BoardcastMessageToPosition(string username, string positionId, string title, string content)
    {
        // get all the user
        var staffs = _staffTable.GetBySQL(
            $"SELECT * FROM `Staff` WHERE `_positionId` = \"{positionId}\""
        );
        if (staffs.Count == 0) return;
        var accountIds = new List<string>();
        foreach (var staff in staffs)
        {
            try
            {
                accountIds.Add(staff.acc.UserName);
            }
            catch (NullReferenceException e) // some staff has no account
            {
            }
        }
        var SendMessageDto = new SendMessageDto()
        {
            receiver = accountIds,
            Title = title,
            content = content + "\r\n\r\n\t(Generated by system)"
        };
        this.SendMessage(username, SendMessageDto);
    }

    public void setMessageRead(string id)
    {
        var message = _receiveMessageTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Staff_Message>($"_messageId:{id}")
        ).FirstOrDefault();

        if (message is null)
        {
            throw new BadArgException("Message is not exist in database.");
        }

        message.Status = Data.Entity.StaffMessageStatus.Read;

        try
        {
            _db.SaveChanges();
        }
        catch (System.Exception)
        {
            throw new OperationFailException("Cannot update message status.");
        }
    }

    public void SendMessage(string SenderUserName, Data.Dto.SendMessageDto message)
    {
        var account = _accountTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{SenderUserName}")
        ).FirstOrDefault();

        if (account is null)
        {
            throw new BadArgException("Account is not exist in database.");
        }

        var newMessage = new Data.Entity.Message
        {
            Title = message.Title,
            Content = message.content,
            SentDate = DateTime.Now,
            _senderId = account.Id,
            sender = account,
            Id = Helpers.Sql.PrimaryKeyGenerator.Get<Data.Entity.Message>(_db)
        };

        _sendMessageTable.Add(newMessage);
        _db.SaveChanges();


        bool isFailed = false;
        StringBuilder failedUsername = new StringBuilder();
        bool hasAdminAccount = false;

        foreach (var recevier in message.receiver)
        {
            var acc = _accountTable.GetBySQL(
                Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{recevier}")
            ).FirstOrDefault();

            ConsoleLogger.Debug(Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{recevier}"));

            var receiverMessage = new Data.Entity.Staff_Message
            {
                _receiverId = acc.Id,
                message = newMessage,
                _messageId = newMessage.Id,
                Status = Data.Entity.StaffMessageStatus.Unreceived
            };
            try
            {
                _receiveMessageTable.Add(receiverMessage);
            }
            catch (System.Exception e)
            {
                ConsoleLogger.Debug(e.Message);
                ConsoleLogger.Debug(e.InnerException);

                isFailed = true;
                failedUsername.Append(recevier + ", ");
            }
        }
#if DEBUG
            var receiverMessage_Admin = new Data.Entity.Staff_Message
            {
                _receiverId =  "A0001",
                message = newMessage,
                _messageId = newMessage.Id,
                Status = Data.Entity.StaffMessageStatus.Unreceived
            };
            try 
            {
                _receiveMessageTable.Add(receiverMessage_Admin);
            }catch(Exception e)
            {
                // ignoreP
            }
#endif

        if (isFailed)
        {
            throw new BadArgException("Some user is not exist in database. " + failedUsername.ToString());
        }

        try
        {
            _db.SaveChanges();

        }
        catch (Exception e)
        {
            throw new OperationFailException("Send message failed.");
        }

    }


    public void BoardcastMessage(string username, string departmentId, string title, string content)
    {
        // get all the user
        var staffs = _staffTable.GetBySQL(
            $"SELECT * FROM `Staff` WHERE `_departmentId` = \"{departmentId}\""
        );
        if (staffs.Count == 0) return;
        var accountIds = new List<string>();
        foreach (var staff in staffs)
        {
            try
            {
                accountIds.Add(staff.acc.UserName);
            }
            catch (NullReferenceException e) // some staff has no account
            {
            }
        }
        var SendMessageDto = new SendMessageDto()
        {
            receiver = accountIds,
            Title = title,
            content = content + "\r\n\r\n\t(Generated by system)"
        };
        this.SendMessage(username, SendMessageDto);
    }

    public bool CheckUserExist(string username)
    {
        var account = _accountTable.GetBySQL(
            Helpers.Sql.QueryStringBuilder.GetSqlStatement<Data.Entity.Account>($"UserName:{username}")
        ).FirstOrDefault();

        if (account is null)
        {
            return false;
        }

        return true;

    }


}