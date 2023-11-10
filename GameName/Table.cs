using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameName {
    public class Table {
        private Dictionary<string, TableDataType> dataTypes = new();
        private Dictionary<string, List<string>> datas = new();

        public bool AddType(string name, int length, bool center = false) {
            if (dataTypes.ContainsKey(name)) return false;
            dataTypes[name] = new TableDataType(name, length, center);
            return true;
        }

        public void AddData(string name, string content) {
            if (!datas.TryGetValue(name, out List<string>? list)) {
                datas[name] = new List<string>();
            }
            list = datas[name];
            list.Add(content);
        }

        public TableDataType[] GetTypes() => dataTypes.Values.ToArray();
        public string[] GetRow(int row) {
            string[] result = new string[dataTypes.Count];
            int index = 0;
            foreach (string key in  dataTypes.Keys) {
                result[index] = datas[key][row];
                index++;
            }
            return result;
        }
        public int GetDataCount() => datas.First().Value.Count;
    }

    public struct TableDataType {
        public string name;
        public int length;
        public bool center = false;
        public TableDataType (string name, int length, bool center = false) {
            this.name = name;
            this.length = length;
            this.center = center;
        }
    }
}
