using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SyslogSrv
{
    [DefaultMemberAttribute("Message")]  
    public class LogLine
    {
        //<43>Sep 12 17:41:04 mike syslog-ng[4165]: Message
        const string REGEX = @"^<(?<level>\d+)>((?<date>\w{3} \w{2} \d{2}:\d{2}:\d{2})( (?<host>\w+))? (?<program>[^\x5B:]+)(\x5B(?<pid>\d+)\x5D)?: )?(?<message>.*)$";
        public enum Facilies
        {
            None = -1,
            Kernel = 0,      // 0 kernel messages
            User,            // 1 user-level messages
            Mail,            // 2 mail system
            Daemon,          // 3 system daemons
            Auth,            // 4 security/authorization messages (note 1)
            Syslog,          // 5 messages generated internally by syslogd
            LPR,             // 6 line printer subsystem
            News,            // 7 network news subsystem
            UUCP,            // 8 UUCP subsystem
            Cron,            // 9 clock daemon (note 2)
            Security,        //10 security/authorization messages (note 1)
            FTP,             //11 FTP daemon
            NTP,             //12 NTP subsystem
            Audit,           //13 log audit (note 1)
            Alert,           //14 log alert (note 1)
            Clock,           //15 clock daemon (note 2)
            Local0,          //16 local use 0  (local0)
            Local1,          //17 local use 1  (local1)
            Local2,          //18 local use 2  (local2)
            Local3,          //19 local use 3  (local3)
            Local4,          //20 local use 4  (local4)
            Local5,          //21 local use 5  (local5)
            Local6,          //22 local use 6  (local6)
            Local7,          //23 local use 7  (local7)
        }

        public enum Severities
        {
            None = -1,
            Emergency = 0,  //0 Emergency: system is unusable
            Alert,          //1 Alert: action must be taken immediately
            Critical,       //2 Critical: critical conditions
            Error,          //3 Error: error conditions
            Warning,        //4 Warning: warning conditions
            Notice,         //5 Notice: normal but significant condition
            Info,           //6 Informational: informational messages
            Debug,          //7 Debug: debug-level messages
        }

        private IPAddress ip;
        private Facilies facility;
        private Severities severity;
        private string date;
        private string host;
        private string program;
        private string pid;
        private string message;

        public LogLine(string msg)
        {
            ip = null;
            facility = Facilies.None;
            severity = Severities.None;

            message = msg;
        }

        public LogLine(IPAddress ip, string msg)
        {
            facility = Facilies.None;
            severity = Severities.None;
            ParseLine(ip, msg);
        }

        public override string ToString()
        {
            return ip.ToString() + " " + severity.ToString() + " " + message;
        }

        public static Facilies ConvertFacility(string level)
        {
            return (Facilies)(Convert.ToInt16(level)/8);
        }

        public static Severities ConvertSeverity(string level)
        {
            return (Severities)(Convert.ToInt16(level)%8);
        }
        
        public void ParseLine(IPAddress ip, string data)
        {
            data = data.TrimEnd(new char[] { '\r', '\n' });
            Message = data;
            IP = ip;

            if (data.StartsWith("<"))
            {
                Regex r = new Regex(REGEX, RegexOptions.Compiled); 
                Match m = r.Match(data);

                if (m.Success)
                {
                    IP = ip;
                    Facility = ConvertFacility(m.Groups["level"].Value);
                    Severity = ConvertSeverity(m.Groups["level"].Value);
                    Date = m.Groups["date"].Value;
                    Host = m.Groups["host"].Value;
                    Program = m.Groups["program"].Value;
                    Pid = m.Groups["pid"].Value;
                    Message = m.Groups["message"].Value;
                }
            }
        }

        #region Properties definitions
        public IPAddress IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public Facilies Facility
        {
            get { return facility; }
            set { facility = value; }
        }
        public Severities Severity
        {
            get { return severity; }
            set { severity = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        public string Program
        {
            get { return program; }
            set { program = value; }
        }
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        #endregion
    }
}
