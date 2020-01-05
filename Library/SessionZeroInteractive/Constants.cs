using System;
using System.Collections.Generic;
using System.Text;

namespace SessionZeroInteractive
{
    static class Constants
    {
        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        public const int TOKEN_ASSIGN_PRIMARY = 0x01;
        public const int TOKEN_DUPLICATE = 0x02;
        public const int TOKEN_IMPERSONATE = 0x04;
        public const int PROCESS_ALL_ACCESS = 0x01;
        public const int ANYSIZE_ARRAY = 0x01;
        public const int TOKEN_ADJUST_PRIVILEGES = 0x20;
        public const int TOKEN_QUERY = 0x08;
        public const int SE_PRIVILEGE_ENABLED = 0x02;
        public const int TOKEN_QUERY_SOURCE = 0x10;
        public const int TOKEN_ADJUST_GROUPS = 0x40;
        public const int TOKEN_ADJUST_DEFAULT = 0x80;
        public const int TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
                                  TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
                                  TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT);
    }
}
