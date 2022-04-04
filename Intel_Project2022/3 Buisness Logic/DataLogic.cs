using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class DataLogic : BaseLogic
    {

        public DateTime Referencedate = new DateTime(2022, 03, 08);
        public string   Active_ShiftSend_Message;
        public DateTime Active_date_Send_Messgae;
      

        public object GetAllModules()
        {
            return DB.ModuleGasLimits.Select(y => new { y.Module }).Distinct();
        }

        public List<ModuleModel> GetAllModulesData()
        {
            return DB.ModuleGasLimits.Select(p => new ModuleModel(p)).ToList();
        }

        public List<ImageModel> GetImage_detailes(string Module)
        {
            return DB.All_Images.Where(p => p.Module == Module).Select(p => new ImageModel(p)).ToList();
        }

        public List<Torque_ListModel> GetAllTorqueList()
        {
            return DB.Torque_List.Select(p => new Torque_ListModel(p)).ToList();
        }

        public List<Torque_ListModel> GetTorqueListPerModule(string module)
        {
            return DB.Torque_List.Where(x => x.Module == module).Select(p => new Torque_ListModel(p)).ToList();
        }

        public List<UserContactModel> GetAllUsers()
        {
            return DB.Contacts_Online.Select(p => new UserContactModel(p)).ToList();
        }

        public List<CommentModel> ShowAllComments()
        {
            return DB.Comments.Select(p => new CommentModel(p)).ToList();
        }

        public object GetToolDataPerModule(string Mod)
        {
            return DB.ModuleGasLimits.Where(p => p.Module == Mod).Select(x => new { x.Tool }).Distinct();
        }

        public List<ToolsPerTool> GetModuleDataPerTool(string Mod)
        {
            return DB.ModuleGasLimits.Where(p => p.Tool == Mod).Select(p => new ToolsPerTool(p)).Distinct().ToList();
        }

        public List<Return_To_taskList> GetAllTasks()
        {
            return DB.Resume.Select(p => new Return_To_taskList(p)).ToList();
        }

        public Return_To_taskList AddTaskToResume(Return_To_taskList New_Task)
        {
            Resume AddNew_Task_ToDB = New_Task.ConvertToResumeModel();
            DB.Resume.Add(AddNew_Task_ToDB);
            DB.SaveChanges();
            New_Task.id = AddNew_Task_ToDB.Id;
            return New_Task;
        }


        public UserContactModel AddUser(UserContactModel New_User)
        {
            Contacts_Online AddNew_User_ToDB = New_User.ConvertToModelUser();
            DB.Contacts_Online.Add(AddNew_User_ToDB);
            DB.SaveChanges();
            New_User.id = AddNew_User_ToDB.Id;
            return New_User;
        }

        public string GetShift(DateTime date)
        {
             updateShift(date);
             return Active_ShiftSend_Message;
        }
 

        public MessageModel AddNewMessage(MessageModel New_Message)
        {
            chat AddNew_Message_ToDB = New_Message.ConvertToModel();
            updateShift(DateTime.Now);
            AddNew_Message_ToDB.Shift = Active_ShiftSend_Message;
            AddNew_Message_ToDB.activedate = DateTime.Now;
            AddNew_Message_ToDB.day = DateTime.Now.Day;
            DB.chat.Add(AddNew_Message_ToDB);
            DB.SaveChanges();
            New_Message.Id = AddNew_Message_ToDB.id;
            return New_Message;
        }

        public void updateShift(DateTime SendMessagedate)
        {
            TimeSpan Difference_dates = SendMessagedate - Referencedate;
            
            switch(Difference_dates.Days%8)
            {
                case 0://08//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                       this.Active_ShiftSend_Message = "1";
                       
                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                       
                        this.Active_ShiftSend_Message = "3";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
              
                        this.Active_ShiftSend_Message = "2";

                    }

                    break;


                case 1://09//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                        
                        this.Active_ShiftSend_Message = "2";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                      
                        this.Active_ShiftSend_Message = "3";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
                       
                        this.Active_ShiftSend_Message = "2";

                    }
                    break;


                case 2: //10//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                       
                        this.Active_ShiftSend_Message = "2";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                     
                        this.Active_ShiftSend_Message = "4";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
         
                        this.Active_ShiftSend_Message = "3";

                    }
                    break;

                case 3: //11///
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                    
                        this.Active_ShiftSend_Message = "3";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                    
                        this.Active_ShiftSend_Message = "4";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
                    
                        this.Active_ShiftSend_Message = "3";

                    }
                    break;


                case 4: //12//

                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                     
                        this.Active_ShiftSend_Message = "3";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                        
                        this.Active_ShiftSend_Message = "1";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
               
                        this.Active_ShiftSend_Message = "4";

                    }
                    break;


                case 5:  //13//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                        
                        this.Active_ShiftSend_Message = "4";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                  
                        this.Active_ShiftSend_Message = "1";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
                    
                        this.Active_ShiftSend_Message = "4";

                    }
                    break;


                case 6:  //14//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                     
                        this.Active_ShiftSend_Message = "4";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                   
                        this.Active_ShiftSend_Message = "2";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
                   
                        this.Active_ShiftSend_Message = "1";

                    }
                    break;


                case 7:  //15//
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                       
                        this.Active_ShiftSend_Message = "1";

                    }
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                        
                        this.Active_ShiftSend_Message = "2";

                    }
                    if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour < 24)
                    {
                      
                        this.Active_ShiftSend_Message = "1";

                    }
                    break;
            }
        }

        public List <MessageModel>GetAllMessages()
        {
            MessageModel LastMessage =  DB.chat.OrderBy(p => p.id).Select(p => new MessageModel(p)).LastOrDefault();
            List<MessageModel> MessageList_PerShift_PerDate = (DB.chat.Where(x => x.Shift == LastMessage.Shift && x.day==DateTime.Now.Day ||x.Shift==LastMessage.Shift && x.day == DateTime.Now.Day-1).OrderBy(x => x.id)).Select(p => new MessageModel(p)).ToList();
            return MessageList_PerShift_PerDate;    
        }

        public List<DataModel> GetAllData()
        {
            return DB.GlUpdatedPassdowns.Select(p => new DataModel(p)).ToList();
        }

        public Return_To_taskList GetoneDataTask(int id)
        {
            return DB.Resume.Where(p => p.Id == id).Select(p => new Return_To_taskList(p)).SingleOrDefault();
        }

        public DataModel GetoneData(int id)
        {
            return DB.GlUpdatedPassdowns.Where(p => p.Id == id).Select(p => new DataModel(p)).SingleOrDefault();
        }

        public Torque_ListModel Get_One_Object_Torque_Model(int id)
        {
            return DB.Torque_List.Where(p => p.id == id).Select(p => new Torque_ListModel(p)).SingleOrDefault();
        }

        public Torque_ListModel Update_NewTorque_To_DB(Torque_ListModel obj)
        {
            Torque_List torque = DB.Torque_List.Where(p => p.id == obj.Id).SingleOrDefault();
            if (torque == null)
                return null;

            torque.Torque = obj.Torque;
            DB.Torque_List.Update(torque);
            DB.SaveChanges();
            obj.Torque = torque.Torque;
            return obj;       
        }

        public ImageModel UpdateTorqueImg(Torque_ListModel torque)
        {
            All_Images img = DB.All_Images.Where(p => p.Module == torque.Module && p.Task == torque.PM && p.part == torque.Part).SingleOrDefault();
            if  (img == null)
                return null;

            img.Torque = torque.Torque;
            DB.All_Images.Update(img);
            DB.SaveChanges();

            return DB.All_Images.Where(p => p.id == img.id).Select(p => new ImageModel(p)).SingleOrDefault();

        }   
        
        public ImageModel UpdateImageData(int id,string torque)
        {
            All_Images img = DB.All_Images.Where(p => p.id == id).SingleOrDefault();
            if (img == null)
               return null;

            img.Torque = torque;
            DB.All_Images.Update(img);
            DB.SaveChanges();

            return DB.All_Images.Where(p => p.id == id).Select(p => new ImageModel(p)).SingleOrDefault(); 

        }

        public UserContactModel Update_If_Type(UserContactModel UserObj)
        {
            Contacts_Online UserContact = DB.Contacts_Online.Where(p => p.UserOnline == UserObj.Name).SingleOrDefault();
            if (UserContact == null)
                return null;

            UserContact.date = DateTime.Now;
            UserContact.Type = UserObj.Type;
            DB.SaveChanges();
            UserObj.Type = UserContact.Type;
            UserObj.Date = UserContact.date;
            return UserObj;
        }

        public UserContactModel Update_If_Not_Type(UserContactModel UserObj)
        {
            Contacts_Online UserContact = DB.Contacts_Online.Where(p => p.UserOnline == UserObj.Name).SingleOrDefault();
            if (UserContact == null)
                return null;

            UserContact.date = null;
            UserContact.Type = null; 
            DB.SaveChanges();
            UserObj.Type = UserContact.Type;
            UserObj.Date = UserContact.date;
            return UserObj;
        }

        public UserContactModel Get_If_Usertype(string Username)
        {
            return DB.Contacts_Online.Where(p => p.Type == "TypeNow" && p.UserOnline != Username).OrderBy(x => x.date).Select(p => new UserContactModel(p)).First();
        }

        //public UserContactModel GetTheFirstTypingUser()
        //{
        //    List<UserContactModel> UsersTypingList = DB.Contacts_Online.Where(p => p.Type == "TypeNow").Select(p => new UserContactModel(p)).ToList();
        //}

        public UserContactModel GetoneUser(string name)
        {
            return DB.Contacts_Online.Where(p => p.UserOnline == name).Select(p => new UserContactModel(p)).SingleOrDefault();
        }

        public MessageModel GetOneMessage(int id)
        {
            return DB.chat.Where(p => p.id == id).Select(p => new MessageModel(p)).SingleOrDefault();
        }

        public DataModel AddTask(DataModel AddNewTask)
        {
            GlUpdatedPassdown NewTask = AddNewTask.ConvertToModel();
            DB.GlUpdatedPassdowns.Add(NewTask);
            DB.SaveChanges();
            AddNewTask.id = NewTask.Id;
            return AddNewTask;
        }

        public CommentModel AddNew_Comment(CommentModel New_comment)
        {
            Comments Add_NewComment = New_comment.ConvertToCommentModel();
            DB.Comments.Add(Add_NewComment);
            DB.SaveChanges();
            New_comment.Id = Add_NewComment.Id;
            return New_comment;
        }

        public string To_delete(int id)
        {
            GlUpdatedPassdown deleteitem = DB.GlUpdatedPassdowns.Where(P => P.Id == id).SingleOrDefault();
            DB.GlUpdatedPassdowns.Remove(deleteitem);
            DB.SaveChanges();
            return "delete done";
        }

        public List<chat> deleteMessage(int id)
        {
            chat To_delete = DB.chat.Where(p => p.id == id).SingleOrDefault();
            DB.chat.Remove(To_delete);
            DB.SaveChanges();
            return DB.chat.ToList();
        }

        public List<Resume> TodeleteItemResume(int id)
        {
            Resume To_delete = DB.Resume.Where(p => p.Id == id).SingleOrDefault();
            DB.Resume.Remove(To_delete);
            DB.SaveChanges();
            return DB.Resume.ToList();
        }

        public List<Contacts_Online> TodeleteUser(string name)
        {
            Contacts_Online To_delete = DB.Contacts_Online.Where(p => p.UserOnline == name).SingleOrDefault();
            DB.Contacts_Online.Remove(To_delete);
            DB.SaveChanges();
            return DB.Contacts_Online.ToList();
        }


       
    }

}
