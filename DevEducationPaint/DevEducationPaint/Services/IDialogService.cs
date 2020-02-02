using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message); 
        string FilePath { get; set; }   
        bool OpenFileDialog();  
        bool SaveFileDialog();  
    }
}
