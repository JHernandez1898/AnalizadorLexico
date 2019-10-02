using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Quindim
{
    [Serializable]
    class BinaryFile<Type>
    {
        private string _strFileName;
        public string FileName
        {
            get { return _strFileName; }
            set { _strFileName = value; }
        }

        private FileStream _fsStream;
        private BinaryFormatter _bfFormatter;

        public BinaryFile(string strFileName)
        {
            _strFileName = strFileName;
        }

        ~BinaryFile()
        {
            Close();
        }

        public void Create()
        {
            _bfFormatter = new BinaryFormatter();
            _fsStream = new FileStream(FileName, FileMode.Create);
        }

        public void OpenInWriteMode()
        {
            if (File.Exists(FileName))
                _fsStream = new FileStream(FileName, FileMode.Append);
            else
                Create();
        }

        public void OpenInReadMode()
        {
            if (File.Exists(FileName))
                _fsStream = new FileStream(FileName, FileMode.Open);
            else
                throw new Exception("This file doesn't exist." + "\n" + FileName);
            _bfFormatter = new BinaryFormatter();
        }

        public void OpenInReadWriteMode()
        {
            if (File.Exists(FileName))
                _fsStream = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite);
            else
                Create();
            _bfFormatter = new BinaryFormatter();
        }

        public void WriteObject(Type anObject)
        {
            _bfFormatter = new BinaryFormatter();
            _bfFormatter.Serialize(_fsStream, anObject);
        }

        public Type ReadObject()
        {
            _bfFormatter = new BinaryFormatter();
            Type anObject = (Type)_bfFormatter.Deserialize(_fsStream);
            return anObject;
        }

        public void Close()
        {
            if (_fsStream != null)
                _fsStream.Close();
        }

        public void DeleteFile()
        {
            File.Delete(FileName);
        }

        public void RenameFile(string strNewFileName)
        {
            File.Move(FileName, strNewFileName);
        }
    }
}