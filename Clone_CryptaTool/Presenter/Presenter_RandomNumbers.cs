using Clone_CryptaTool.Interface;
using Clone_CryptaTool.Model;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Clone_CryptaTool.Presenter
{
    class Presenter_RandomNumbers
    {
        private Model_RandomGenerator model;
        private IView_RandomPage view;

        public Presenter_RandomNumbers(IView_RandomPage view)
        {
            this.view = view;
            model = new Model_RandomGenerator();
            model.arrangment = view.arrangment;
        }
        public Presenter_RandomNumbers(IView_RandomPage view, long seed)
        {
            this.view = view;
            model = new Model_RandomGenerator(seed);
        }

        public async void Next()
        {
            model.countNumbers = view.countNimbers;
            if (view.arrangment == false)
            {
                if (model.countNumbers != 0)
                {
                    for (int i = 0; i < model.countNumbers; i++)
                    {
                        await Task.Run(() => model.next());
                        view.randomNumber = model.randomNumber;
                    }
                }
                else
                {
                    await Task.Run(() => model.next());
                    view.randomNumber = model.randomNumber;
                }
            }
            if (view.arrangment == true)
            {
                if (model.countNumbers != 0)
                {
                    for (int i = 0; i < model.countNumbers; i++)
                    {
                        long minValue = view.fromFirstNumber;
                        long maxValue = view.toSecondNumber;
                        await Task.Run(() => model.next(minValue, maxValue));
                        view.randomNumber = model.randomNumber;
                    }
                }
                else
                {
                    long minValue = view.fromFirstNumber;
                    long maxValue = view.toSecondNumber;
                    await Task.Run(() => model.next(minValue, maxValue));
                    view.randomNumber = model.randomNumber;
                }
            }
        }
    }
}
