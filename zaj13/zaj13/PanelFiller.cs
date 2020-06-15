using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace zaj13
{
    class PanelFiller : IPanelFiller
    {
        private readonly IControlGenerator _controlGenerator;
        private readonly IDataProvider _dataProvider;

        public PanelFiller(IControlGenerator controlGenerator, IDataProvider dataProvider)
        {
            _controlGenerator = controlGenerator;
            _dataProvider = dataProvider;
        }

        public void Fill(Panel panel)
        {
            var number = _dataProvider.GetData();

            for (int i = 0; i < number; i++)
            {
                panel.Children.Add(_controlGenerator.Generate());
            }
        }

    }
}
