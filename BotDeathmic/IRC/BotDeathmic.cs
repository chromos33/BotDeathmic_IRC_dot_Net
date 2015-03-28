using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrcDotNet;
using DeathmicChatbot.Exceptions;
using DeathmicChatbot.IRC;
using DeathmicChatbot.Properties;

namespace DeathmicChatbot.IRC
{
    public class BotDeathmic : BasicIrcBot
    {
        String[] IgnoreTheseUsers = new String[] {"AUTH","Global","py-ctcp","peer"};
        public BotDeathmic()
            : base()
        {
        }

        public override IrcRegistrationInfo RegistrationInfo
        {
            get
            {
                return new IrcUserRegistrationInfo()
                {
                    NickName = Properties.Settings.Default.Name,
                    UserName = Properties.Settings.Default.Name,
                    RealName = Properties.Settings.Default.Name
                };
            }
        }

        protected override void OnClientConnect(IrcClient client)
        {

        }

        protected override void OnClientDisconnect(IrcClient client)
        {
            //
        }

        protected override void OnClientRegistered(IrcClient client)
        {
            //
        }

        protected override void OnLocalUserJoinedChannel(IrcLocalUser localUser, IrcChannelEventArgs e)
        {
        }

        protected override void OnLocalUserLeftChannel(IrcLocalUser localUser, IrcChannelEventArgs e)
        {
            //
        }

        protected override void OnLocalUserNoticeReceived(IrcLocalUser localUser, IrcMessageEventArgs e)
        {
            //
        }

        protected override void OnLocalUserMessageReceived(IrcLocalUser localUser, IrcMessageEventArgs e)
        {
            //
        }

        protected override void OnChannelUserJoined(IrcChannel channel, IrcChannelUserEventArgs e)
        {
        }

        protected override void OnChannelUserLeft(IrcChannel channel, IrcChannelUserEventArgs e)
        {
            //
        }

        protected override void OnChannelNoticeReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            //
        }

        protected override void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e)
        {

        }

        protected override void InitializeChatCommandProcessors()
        {
            base.InitializeChatCommandProcessors();
            this.ChatCommandProcessors.Add("test", Test);

            

        }

        private void Test(IrcClient client, IIrcMessageSource source, IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;

            if (parameters.Count != 0)
                throw new InvalidCommandParametersException(1);

            // List all currently logged-in twitter users.
            var replyTargets = GetDefaultReplyTarget(client, sourceUser, targets);

            string test = "";
            foreach (var target in client.Users)
            {
                
                if (!IgnoreTheseUsers.Contains(target.NickName))
                {
                    test += target.NickName + ", ";
                }
            }
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            client.LocalUser.SendMessage(targets, "These Users are currently in this channel: " + test);
            
            
            //client.LocalUser.SendMessage(replyTargets., replyTargets.Count().ToString(), Encoding.UTF8);
            

        }

        #region Chat Command Processors

        private void ProcessChatCommandListUsers(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;

            if (parameters.Count != 0)
                throw new InvalidCommandParametersException(1);

            // List all currently logged-in twitter users.
            var replyTargets = GetDefaultReplyTarget(client, sourceUser, targets);

            throw new NotImplementedException();
        }

        private void ProcessChatCommandLogIn(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;
            
            throw new NotImplementedException();
                // Log-in failed.

                //client.LocalUser.SendMessage(replyTargets, "Invalid log-in username/password.");
        }

        private void ProcessChatCommandLogOut(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;
           
        }

        private void ProcessChatCommandSend(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;
            throw new NotImplementedException();
            if (parameters.Count != 1)
            {

            }
                
        }

        private void ProcessChatCommandHome(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;
            throw new NotImplementedException();
        }

        private void ProcessChatCommandMentions(IrcClient client, IIrcMessageSource source,
            IList<IIrcMessageTarget> targets, string command, IList<string> parameters)
        {
            var sourceUser = (IrcUser)source;
            throw new NotImplementedException();
        }

        #endregion

        private string SanitizeTextForIrc(string value)
        {
            var sb = new StringBuilder(value);
            sb.Replace('\r', ' ');
            sb.Replace('\n', ' ');
            return sb.ToString();
        }

        protected override void InitializeCommandProcessors()
        {
            base.InitializeCommandProcessors();
        }

        #region Command Processors

        //

        #endregion
    }
}
