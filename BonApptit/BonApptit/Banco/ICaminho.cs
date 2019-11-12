using System;
using System.Collections.Generic;
using System.Text;

namespace BonApptit.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);
    }
}
