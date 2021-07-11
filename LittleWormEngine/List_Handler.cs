using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    public static class List_Handler
    {


        public static void AddtoList<T>(List<T> _List,T _Item)
        {
            _List.Add(_Item);
        }

        public static void RemovefromList<T>(List<T> _List, T _Item)
        {
            _List.Remove(_Item);
        }
    }
}
