using Clone_CryptaTool.Interface;
using System;
using System.Collections.Generic;
using System.Text;



namespace Clone_CryptaTool
{
    class Presenter
    {
        private IView view;
        private Model model;

        public Presenter(IView view)
        {
            this.view = view;
            this.model = new Model();
        }

        public void encode ()
        {
            model.beforeText = view.beforeText;
            model.keyWord = view.keyWord;
            if (view.currentOperation == 0)
                model.encodeToAtabash();
            if (view.currentOperation == 1)
                model.encodeToVigener();
            if (view.currentOperation == 2)
            {
                model.encodeToFestiel();
                view.keyWord = model.keyWord;
            } 
            if (view.currentOperation == 3)
                model.encodeToUseOpenKey();
            if (view.currentOperation == 4)
                model.encodeToAtabash();
            view.afterText = model.afterText;            
        }
        public void decode()
        {
            model.beforeText = view.beforeText;
            model.keyWord = view.keyWord;
            if (view.currentOperation == 0)
                model.decodeFromAtabash();
            if (view.currentOperation == 1)
                model.decodeFromVigener();
            if (view.currentOperation == 2)
            { 
                model.decodeFromFestiel();
                view.keyWord = model.keyWord;
            }
            if (view.currentOperation == 3)
                model.decodeFromUseOpenKey();
            if (view.currentOperation == 4)
                model.randomNumber();
            view.afterText = model.afterText;
        }


    }
}
