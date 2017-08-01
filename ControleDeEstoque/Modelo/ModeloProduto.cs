using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProduto
    {
        public ModeloProduto()
        {
            this.ProCod = 0;
            this.ProNome = "";
            this.ProDescricao = "";
            //this.ProFoto = "";
            this.ProValorPago = 0;
            this.ProValorVenda = 0;
            this.ProQtde = 0;
            this.UmedCod = 0;
            this.CatCod = 0;
            this.ScatCod = 0;
        }
        public ModeloProduto(int _pro_cod, String _pro_nome, String _pro_descricao, String _pro_foto, Double _pro_valorpago, Double _pro_valorvenda,
           Double _pro_qtde, int _umed_cod, int _cat_cod, int _scat_cod)
        {
            this.ProCod = _pro_cod;
            this.ProNome = _pro_nome;
            this.ProDescricao = _pro_descricao;
            this.CarregaImagem(_pro_foto);
            this.ProValorPago = _pro_valorpago;
            this.ProValorVenda = _pro_valorvenda;
            this.ProQtde = _pro_qtde;
            this.UmedCod = _umed_cod;
            this.CatCod = _cat_cod;
            this.ScatCod = _scat_cod;
        }


        public ModeloProduto(int _pro_cod, String _pro_nome, String _pro_descricao, byte[] _pro_foto, Double _pro_valorpago, Double _pro_valorvenda, 
            Double _pro_qtde, int _umed_cod, int _cat_cod, int _scat_cod)
        {
            this.ProCod = _pro_cod;
            this.ProNome = _pro_nome;
            this.ProDescricao = _pro_descricao;
            this.ProFoto = _pro_foto;
            this.ProValorPago = _pro_valorpago;
            this.ProValorVenda = _pro_valorvenda;
            this.ProQtde = _pro_qtde;
            this.UmedCod = _umed_cod;
            this.CatCod = _cat_cod;
            this.ScatCod = _scat_cod;
        }

        private int _pro_cod;
        public int ProCod
        {
            get { return this._pro_cod; }
            set { this._pro_cod = value; }
        }
        private string _pro_nome;
        public string ProNome
        {
            get { return this._pro_nome; }
            set { this._pro_nome = value; }
        }
        private String _pro_descricao;
        public String ProDescricao
        {
            get { return this._pro_descricao; }
            set { this._pro_descricao = value; }
        }
        private byte[] _pro_foto;
        public byte[] ProFoto
        {
            get { return this._pro_foto; }
            set { this._pro_foto = value; }
        }
        public void CarregaImagem(String imgCaminho)
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho))
                {
                    return;
                    //fornece propiedades e metodos de instacia para criar, copiar
                    //excluir, mover, abrir arquivos e ajuda na criação de objetos FileStream
                    FileInfo arqImagem = new FileInfo(imgCaminho);
                    //expoe um stream ao redor de um arquivo suporte
                    //sincrono e assincrono operarções de leitura e gravação.
                    FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);
                    // aloca memória para o vetor
                    this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];
                    // lê um bloque de bytes do fluxo e grava os dados em um buffer fornecido
                    int iByteRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));
                    fs.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        private Double _pro_valorpago;
        public Double ProValorPago
        {
            get { return this._pro_valorpago; }
            set { this._pro_valorpago = value; }
        }
        private Double _pro_valorvenda;
        public Double ProValorVenda
        {
            get { return this._pro_valorvenda; }
            set { this._pro_valorvenda = value; }
        }
        private Double _pro_qtde;
        public Double ProQtde
        {
            get { return this._pro_qtde; }
            set { this._pro_qtde = value; }
        }
        private int _umed_cod;
        public int UmedCod
        {
            get { return this._umed_cod; }
            set { this._umed_cod = value; }
        }

        private int _cat_cod;
        public int CatCod
        {
            get { return this._cat_cod; }
            set { this._cat_cod = value; }
        }
        private int _scat_cod;
        public int ScatCod
        {
            get { return this._scat_cod; }
            set { this._scat_cod = value; }
        }
    }
}
