using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonApptit.Modelos;
using System.Threading.Tasks;
using BonApptit.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace BonApptit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaPedido : ContentPage
    {
        Pedido pedido = new Pedido(); // teste
        List<Pedido> lista = new List<Pedido>();
        Adicional adicional = new Adicional();
        public double LancheSoma, AdicionalSoma, AcompanhamentoSoma, BebidasSoma, SobremesaSoma;
        public Lanches  LancheSelecionado;

        Lanches l = new Lanches();
        

        DataBase banco = new DataBase();
        public Mesa mesa;

        bool tap = true, tap2 = true, tap3 = true, tap4=true, tap5=true,  count = false;

        public TelaPedido(Mesa mesa, DataBase banco, List<Pedido> lista)
        {


            InitializeComponent();
            

            BindingContext = pedido;
            this.mesa = mesa;
            this.banco = banco;
            this.lista = lista;
            
            banco.InserirMesa(this.mesa);
        
            lblNome.FontFamily = Device.OnPlatform("Sansation", "Sansation_Bold_Italic.ttf#Phenomena Black", "Assets/Sansation_Bold_Italic.ttf#Sansation");
       
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                  
                    break;
                default:
                   
                    break;
            }


            lblNome.Text = "Realize seu pedido, " + mesa.nome + "!";
            lanches.BindingContext = ListaLanches();
            lanches.ItemsSource = ListaLanches();
            Bebidas.ItemsSource = ListaBebidas();
            seletorLanche.ItemsSource = SelecionarLanche();
            lanches.IsVisible = false;
            Bebidas.IsVisible = false;
            sobremesas.IsVisible = false;
            Acompanhamentos.IsVisible = false;
            SeletorElista.IsVisible = false;


            Adicional.BindingContext = ListaAdicional();
            Adicional.ItemsSource = ListaAdicional();



            Acompanhamentos.ItemsSource = ListaAcompanhamentos();

            sobremesas.ItemsSource = ListaSobremesas();
            



            pedido.totalPedido = 0;



        }


        private void Total()
        {
            pedido.totalPedido = LancheSoma + AdicionalSoma + AcompanhamentoSoma + BebidasSoma + SobremesaSoma; 
        }


        #region lanches
        private void adicionarLanche(object sender, ValueChangedEventArgs e)
        {

            var lista = (List<Lanches>)lanches.ItemsSource;

           
            lista.ForEach(l => l.precoTotal = l.quantidade * l.preco);
            LancheSoma = lista.Sum(l => l.precoTotal);
            Total();


            if (lista.Count > 0)
            {
                count = true;
            }
            

        }


      
        private List<Lanches> ListaLanches()
        {

            var lanches = new List<Lanches>();



            var tradicional = new Lanches { nome = "Tradicional",  preco = 23.00 , descricao = "Exclusivo e delicioso! Receita própria, coberto com queijo mussarela derretido, cubinhos de bacon, alface, cebola e tomate.", quantidade = 0, precoTotal = 0 };
            var barreado = new Lanches { nome = "Barreado", preco = 26.00, descricao = "O primeiro do mundo! Coberto com queijo mussarela derretido, cubinhos de bacon, cebola e fatias de banana, Balinhas de banana vão de brinde.", quantidade = 0, precoTotal = 0 };
            var Blumenau = new Lanches { nome = "Blumenau", preco = 25.00, descricao = "Sabor indescritivel. Coberto com queijo mussarela derretido, cubinhos de bacon, agrião, cebola e tomate. ", quantidade = 0, precoTotal = 0 };
            var pernil = new Lanches { nome = "Pernil", preco = 25.00, descricao = "Coberto com queijo provolone derretido, alface e o incrivel barbecue de goiabada.", quantidade = 0, precoTotal = 0 };
            var vegetariano = new Lanches { nome = "Vegetariano", preco = 24.00, descricao = "Feito de proteina de soja, quinoa e ervas frescas, coberto com queijo mussarela derretido, sour cream com cenoura, cebola, tomate e alface.", quantidade = 0, precoTotal = 0 };

            lanches.Add(tradicional);
            lanches.Add(barreado);
            lanches.Add(Blumenau);
            lanches.Add(pernil);
            lanches.Add(vegetariano);


            return lanches;
        }

    
        
        private List<Lanches> SelecionarLanche()

        {
           
                var lista = (List<Lanches>)lanches.ItemsSource;


             

                return lista.Where(L => L.quantidade > 0).ToList();
            
          
            
        }


       




        private void TapLanches(object sender, EventArgs args)
        {
            if (tap == true)
            {

                lanches.IsVisible = true;
                tap = false;
            }
            else
            {
                lanches.IsVisible = false;
                tap = true;
            }

        }

        #endregion

        #region Adicional
        private List<Adicional> ListaAdicional()
        {
            var Adicional = new List<Adicional>();


            var Molho = new Adicional { nome = "Molho", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var Bacon = new Adicional { nome = "Bacon", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var Queijo = new Adicional { nome = "Queijo", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var AnelCebola = new Adicional { nome = "Anel Cebola", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var CebolaCaramelizada = new Adicional { nome = "Cebola Caramelizada", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var ChedarCremoso = new Adicional { nome = "Cheddar Cremoso", preco = 1.50, quantidade = 0, precoTotal = 0 };
            var Carne = new Adicional { nome = "Carne", preco = 7.00, quantidade = 0, precoTotal = 0 };

            Adicional.Add(Molho);
            Adicional.Add(Bacon);
            Adicional.Add(Queijo);
            Adicional.Add(AnelCebola);
            Adicional.Add(CebolaCaramelizada);
            Adicional.Add(ChedarCremoso);
            Adicional.Add(Carne);

            return Adicional;



        }

        private void SelLanches(object sender, EventArgs args)
        {
            Picker obj = (Picker)sender;
            LancheSelecionado = (Lanches)obj.SelectedItem; 
        }

        private void MensagemAdicional(string nome)
        {
            bool a = true, c = true;
            var l = (List<Lanches>)lanches.ItemsSource;
            var A = (List<Adicional>)Adicional.ItemsSource;
            var E = A.Where(ad => ad.quantidade > 0);
            foreach (var item in A)
            {
                if (item.quantidade == 0 && 
                   E.Count() == 0)
                {
                    c = false;
                }
            }

            
            foreach (var item in l)
            {
                if (item.nome == nome && item.quantidade == 0)
                {
                    a = false;
                }
            }


            if (c == true)
            {
                if (a == true)
                {
                    if (SelecionarLanche().Count > 0)
                    {
                        mensagemConfirmada.Text = "Adicional adicionado no Lanche: " + nome + "!";
                        mensagemConfirmada.TextColor = Color.Green;
                        Adicional.ItemsSource = ListaAdicional();
                    }
                }

                else
                {
                    mensagemConfirmada.Text = "Selecione um lanche antes de confirmar o adicional";
                    mensagemConfirmada.TextColor = Color.Red;
                }
            }
            else
            {
                mensagemConfirmada.Text = "Adicione um adicional antes de confirmar!";
                mensagemConfirmada.TextColor = Color.Red;
                c = true;
            }
        }

        private void ConfirmarAdicional(object sender, EventArgs args)
        {

            if (LancheSelecionado == null)
            {
                mensagemConfirmada.Text = "Selecione um lanche antes de confirmar o adicional";
                mensagemConfirmada.TextColor = Color.Red;
            }

           else if (LancheSelecionado.nome == "Tradicional")
            {
                

                foreach (var item in SelecionarLanche())
                {
                    if (item.nome == "Tradicional")
                    {
                        item.adicional = SelecionarAdicional();
                    }
                }

                
                MensagemAdicional(LancheSelecionado.nome);

               
            }

            else if (LancheSelecionado.nome == "Barreado")
            {


                foreach (var item in SelecionarLanche())
                {
                    if (item.nome == "Barreado")
                    {
                        item.adicional = SelecionarAdicional();
                    }
                }

                MensagemAdicional(LancheSelecionado.nome);

            }

           else if (LancheSelecionado.nome == "Blumenau")
            {

                foreach (var item in SelecionarLanche())
                {
                    if (item.nome == "Blumenau")
                    {
                        item.adicional = SelecionarAdicional();
                    }
                }

                MensagemAdicional(LancheSelecionado.nome);
            }

           else if (LancheSelecionado.nome == "Pernil")
            {

                foreach (var item in SelecionarLanche())
                {
                    if (item.nome == "Pernil")
                    {
                        item.adicional = SelecionarAdicional();
                    }
                }

                MensagemAdicional(LancheSelecionado.nome);
            }

           else if (LancheSelecionado.nome == "Vegetariano")
            {

                foreach (var item in SelecionarLanche())
                {
                    if (item.nome == "Vegetariano")
                    {
                        item.adicional = SelecionarAdicional();
                    }
                }

                MensagemAdicional(LancheSelecionado.nome);
            }




        }



        private void TapAdicional(object sender, EventArgs args)
        {
            if (tap2 == true)
            {

                if (count == true)
                {

                    seletorLanche.ItemsSource = SelecionarLanche();


                    SeletorElista.IsVisible = true;
                    tap2 = false;
                }

                else
                {
                    mensagemConfirmada.Text = "Selecione um lanche antes de selecionar um adicional!";
                    mensagemConfirmada.TextColor = Color.Red;
                }
            }
            else
            {
               SeletorElista.IsVisible = false;
                
                tap2 = true;
            }


          

        }

        private void adicionarAdicional(object sender, ValueChangedEventArgs args)
        {
          


            var lista = (List<Adicional>)Adicional.ItemsSource;
            var list = (List<Acompanhamento>)Acompanhamentos.ItemsSource;
            var lis = list.Where(li => li.quantidade == 0);
            
         
                lista.ForEach(l => l.precoTotal = l.quantidade * l.preco);
            AdicionalSoma = lista.Sum(l => l.precoTotal);
            Total();


        }



        private List<Adicional> SelecionarAdicional()

        {
            var lista = (List<Adicional>)Adicional.ItemsSource;

            return lista.Where(A => A.quantidade > 0).ToList();
        }

        #endregion


        #region Acompanhamento
        private List<Acompanhamento> ListaAcompanhamentos()
        {
            var Acompanhamento = new List<Acompanhamento>();

            var BatataCanoa = new Acompanhamento { nome = "Batata Canoa", preco = 7.00, quantidade = 0, precoTotal = 0 };
            var PolentaPalito = new Acompanhamento { nome = "Polenta Palito", preco = 7.00, quantidade = 0, precoTotal = 0 };
            var BatataDoceChips = new Acompanhamento { nome = "Batata Doce Chips", preco = 7.00, quantidade = 0, precoTotal = 0 };
            var Barbecue = new Acompanhamento { nome = "Barbecue", preco = 2.50, quantidade = 0, precoTotal = 0 };
            var MaioneseDeErvas = new Acompanhamento { nome = "Maionese de Ervas", preco = 2.50, quantidade = 0, precoTotal = 0 };
            var MaioneseDeAlho = new Acompanhamento { nome = "Maionese de Alho", preco = 2.50, quantidade = 0, precoTotal = 0 };

            Acompanhamento.Add(BatataCanoa);
            Acompanhamento.Add(PolentaPalito);
            Acompanhamento.Add(BatataDoceChips);
            Acompanhamento.Add(Barbecue);
            Acompanhamento.Add(MaioneseDeErvas);
            Acompanhamento.Add(MaioneseDeAlho);

            return Acompanhamento;

        }

        private void adicionarAcompanhamentos (object sender, ValueChangedEventArgs e)
        {
         
            var list = (List<Adicional>)Adicional.ItemsSource;
            var lista = (List<Acompanhamento>)Acompanhamentos.ItemsSource;

          var  lis = list.Where(li => li.quantidade == 0);
           

          
            

           lista.ForEach(l => l.precoTotal = l.quantidade * l.preco);

           AcompanhamentoSoma = lista.Sum(l => l.precoTotal);



            Total();



        }




        private List<Acompanhamento> SelecionarAcompanhamentos()

        {
            var lista = (List<Acompanhamento>)Acompanhamentos.ItemsSource;

            return lista.Where(A => A.quantidade > 0).ToList();
        }




        private void TapAcompanhamento(object sender, EventArgs args)
        {
            if (tap3 == true)
            {

                Acompanhamentos.IsVisible = true;
                tap3 = false;
            }
            else
            {
                Acompanhamentos.IsVisible = false;
                tap3 = true;
            }

        }
        #endregion

        #region Bebidas
        private List<Bebida> ListaBebidas()
        {
            var Bebida = new List<Bebida>();

            var CervejaLatao = new Bebida { nome = "Cerveja Latão", preco = 5.00, quantidade = 0, precoTotal = 0};
            var Refrigerante1 = new Bebida { nome = "Refrigerante 2 L", preco = 7.50, quantidade = 0, precoTotal = 0 };
            var Refrigerante2 = new Bebida { nome = "Refrigerante 600 ML", preco = 4.90, quantidade = 0, precoTotal = 0 };
            var Refrigerante3 = new Bebida { nome = "Refrigerante Lata 350 ML", preco = 3.90, quantidade = 0, precoTotal = 0 };
            var Refrigerante4 = new Bebida { nome = "Refrigerante Mini Lata", preco = 2.50, quantidade = 0, precoTotal = 0 };
            var SucoCaixa1 = new Bebida { nome = "Suco Caixa 1 L", preco = 5.00, quantidade = 0, precoTotal = 0 };
            var SucoCaixa2 = new Bebida { nome = "Suco Caixa 200 ML", preco = 2.00, quantidade = 0, precoTotal = 0 };
            var SucoCaixa3 = new Bebida { nome = "Suco Caixa 350 ML", preco = 3.90, quantidade = 0, precoTotal = 0 };



            Bebida.Add(CervejaLatao);
            Bebida.Add(Refrigerante1);
            Bebida.Add(Refrigerante2);
            Bebida.Add(Refrigerante3);
            Bebida.Add(Refrigerante4);
            Bebida.Add(SucoCaixa1);
            Bebida.Add(SucoCaixa2);
            Bebida.Add(SucoCaixa3);

            return Bebida;

        }

        private void adicionarBebidas(object sender, ValueChangedEventArgs e)
        {

            var lista = (List<Bebida>)Bebidas.ItemsSource;






            lista.ForEach(l => l.precoTotal = l.quantidade * l.preco);

            BebidasSoma = lista.Sum(l => l.precoTotal);



            Total();



        }

        private List<Bebida> SelecionarBebidas()

        {
            var lista = (List<Bebida>)Bebidas.ItemsSource;

            return lista.Where(A => A.quantidade > 0).ToList();
        }

        private void TapBebida(object sender, EventArgs args)
        {
            if (tap4 == true)
            {

                Bebidas.IsVisible = true;
                tap4 = false;
            }
            else
            {
                Bebidas.IsVisible = false;
                tap4 = true;
            }

        }



        #endregion

        #region Sobremesas
        private List<Sobremesa> ListaSobremesas()
        {
            var Sobremesa = new List<Sobremesa>();

            var Brownie = new Sobremesa { nome = "Brownie", descricao = "Servido com uma bola de sorvete.",  preco = 18.70, quantidade = 0, precoTotal = 0 };
            var CrumbleDeMaca = new Sobremesa { nome = "Crumble de Maçã", descricao = "Com calda de baunilha e sorvete de canela.", preco = 19.90, quantidade = 0, precoTotal = 0 };
            var Cheescake = new Sobremesa { nome = "Cheescake", descricao = "Servido com calda de framboesa, morango ou chocolate. Acompanhado de chantilly.", preco = 18.30, quantidade = 0, precoTotal = 0 };
            var PetitGateau = new Sobremesa { nome = "Petit Gateau", descricao = "Com calda de chocolate ou doce de leite, servido com uma bola de sorvete de creme.", preco = 19.90, quantidade = 0, precoTotal = 0 };
            var Sundae = new Sobremesa { nome = "Sundae" , descricao = "Duas bolas de sorvete, duas caldas, chantilly e farofa de castanhas", preco = 16.80, quantidade = 0, precoTotal = 0 };


            Sobremesa.Add(Brownie);
            Sobremesa.Add(CrumbleDeMaca);
            Sobremesa.Add(Cheescake);
            Sobremesa.Add(PetitGateau);
            Sobremesa.Add(Sundae);

            return Sobremesa;






        }

        private void adicionarSobremesas(object sender, ValueChangedEventArgs e)
        {

            var lista = (List<Sobremesa>)sobremesas.ItemsSource;






            lista.ForEach(l => l.precoTotal = l.quantidade * l.preco);

            SobremesaSoma = lista.Sum(l => l.precoTotal);



            Total();



        }

        private List<Sobremesa> SelecionarSobremesas()

        {
            var lista = (List<Sobremesa>)sobremesas.ItemsSource;

            return lista.Where(A => A.quantidade > 0).ToList();
        }

        private void TapSobremesa(object sender, EventArgs args)
        {
            if (tap5 == true)
            {

                sobremesas.IsVisible = true;
                tap5 = false;
            }
            else
            {
                sobremesas.IsVisible = false;
                tap5 = true;
            }

        }


        #endregion
        private void Adicionar(object sender, EventArgs args)
        {
            if (pedido.totalPedido > 0)
            {
                pedido.lanches = SelecionarLanche();
                pedido.acompanhamentos = SelecionarAcompanhamentos();
                pedido.bebidas = SelecionarBebidas();
                pedido.sobremesas = SelecionarSobremesas();
                
                Navigation.PushAsync(new ConfirmarPedido(pedido, this.mesa, banco, lista));
            }
            else
            {
                mensagemConfirmada.Text = "Para prosseguir é necessário realizar um pedido!";
                mensagemConfirmada.TextColor = Color.Red;
            }
        }
    }

}
