namespace Providencia.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PRV_Model : DbContext
    {
        public PRV_Model()
            : base("name=PRV_Model")
        {
        }

        public PRV_Model(string conn)
            : base(conn)
        {
        }

        public virtual DbSet<PRV_BENEFICIOS> PRV_BENEFICIOS { get; set; }
        public virtual DbSet<PRV_BENEFICIOS_FAMILIA> PRV_BENEFICIOS_FAMILIA { get; set; }
        public virtual DbSet<PRV_CONSTITUICAO_FAMILIAR> PRV_CONSTITUICAO_FAMILIAR { get; set; }
        public virtual DbSet<PRV_DADOS_ESCOLARES_FAMILIA> PRV_DADOS_ESCOLARES_FAMILIA { get; set; }
        public virtual DbSet<PRV_DESPESA_FAMILIAR> PRV_DESPESA_FAMILIAR { get; set; }
        public virtual DbSet<PRV_EDUCANDO> PRV_EDUCANDO { get; set; }
        public virtual DbSet<PRV_ESCOLARIDADE> PRV_ESCOLARIDADE { get; set; }
        public virtual DbSet<PRV_ESCOLARIDADE_EDUCANDO> PRV_ESCOLARIDADE_EDUCANDO { get; set; }
        public virtual DbSet<PRV_ESTADO_CIVIL> PRV_ESTADO_CIVIL { get; set; }
        public virtual DbSet<PRV_GRUPO> PRV_GRUPO { get; set; }
        public virtual DbSet<PRV_GRUPO_TERAPEUTICO> PRV_GRUPO_TERAPEUTICO { get; set; }
        public virtual DbSet<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR> PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR { get; set; }
        public virtual DbSet<PRV_MORADIA> PRV_MORADIA { get; set; }
        public virtual DbSet<PRV_MORADORES_RESIDENCIA_EDUCANDO> PRV_MORADORES_RESIDENCIA_EDUCANDO { get; set; }
        public virtual DbSet<PRV_RENDA_FAMILIAR> PRV_RENDA_FAMILIAR { get; set; }
        public virtual DbSet<PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR> PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR { get; set; }
        public virtual DbSet<PRV_TIPO_DE_FAMILIA> PRV_TIPO_DE_FAMILIA { get; set; }
        public virtual DbSet<PRV_TIPO_MORADIA> PRV_TIPO_MORADIA { get; set; }
        public virtual DbSet<PRV_UNIDADE> PRV_UNIDADE { get; set; }
        public virtual DbSet<PRV_USUARIO> PRV_USUARIO { get; set; }
        public virtual DbSet<PRV_VIOLENCIA_NA_FAMILIA> PRV_VIOLENCIA_NA_FAMILIA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRV_BENEFICIOS>()
                .Property(e => e.PRV_DESCRICAO_BENEFICIOS)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_BENEFICIOS>()
                .HasMany(e => e.PRV_BENEFICIOS_FAMILIA)
                .WithRequired(e => e.PRV_BENEFICIOS)
                .HasForeignKey(e => e.PRV_ID_BENEFICIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .Property(e => e.PRV_NOME_MEMBRO_FAMILIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .Property(e => e.PRV_PARENTESCO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .Property(e => e.PRV_PROFISSAO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .HasMany(e => e.PRV_BENEFICIOS_FAMILIA)
                .WithRequired(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .HasForeignKey(e => e.PRV_ID_MEMBRO_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .HasMany(e => e.PRV_DADOS_ESCOLARES_FAMILIA)
                .WithRequired(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .HasForeignKey(e => e.PRV_ID_MEMBRO_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .HasMany(e => e.PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR)
                .WithRequired(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .HasForeignKey(e => e.PRV_ID_MEMBRO_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .HasMany(e => e.PRV_MORADORES_RESIDENCIA_EDUCANDO)
                .WithRequired(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .HasForeignKey(e => e.PRV_ID_MEMBRO_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_CONSTITUICAO_FAMILIAR>()
                .HasMany(e => e.PRV_VIOLENCIA_NA_FAMILIA)
                .WithRequired(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .HasForeignKey(e => e.PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_DESPESA_FAMILIAR>()
                .Property(e => e.PRV_DESCRICAO_DESPESA_FAMILIAR)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NOME_EDUCANDO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NOME_RESPONSAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_TELEFONE_RESPONSAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NOME_MAE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_TELEFONE_MAE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NOME_PAI)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_TELEFONE_PAI)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_TELEFONE_RESIDENCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NOME_RUA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_CEP)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .Property(e => e.PRV_NA_AUSENCIA_RESPONSAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .HasMany(e => e.PRV_CONSTITUICAO_FAMILIAR)
                .WithRequired(e => e.PRV_EDUCANDO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .HasMany(e => e.PRV_MORADIA)
                .WithRequired(e => e.PRV_EDUCANDO)
                .HasForeignKey(e => e.PRV_ID_EDUCANDO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .HasMany(e => e.PRV_ESCOLARIDADE_EDUCANDO)
                .WithRequired(e => e.PRV_EDUCANDO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_EDUCANDO>()
                .HasMany(e => e.PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR)
                .WithOptional(e => e.PRV_EDUCANDO)
                .HasForeignKey(e => e.FK_ID_EDUCANDO_ROTINA);

            modelBuilder.Entity<PRV_ESCOLARIDADE>()
                .Property(e => e.PRV_DESCRICAO_ESCOLARIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ESCOLARIDADE>()
                .HasMany(e => e.PRV_DADOS_ESCOLARES_FAMILIA)
                .WithRequired(e => e.PRV_ESCOLARIDADE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_ESCOLARIDADE_EDUCANDO>()
                .Property(e => e.PRV_ENSINO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ESCOLARIDADE_EDUCANDO>()
                .Property(e => e.PRV_TURNO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ESCOLARIDADE_EDUCANDO>()
                .Property(e => e.PRV_REPETINDO_SERIE_ATUAL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ESTADO_CIVIL>()
                .Property(e => e.PRV_DESCRICAO_ESTADO_CIVIL)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ESTADO_CIVIL>()
                .HasMany(e => e.PRV_EDUCANDO)
                .WithRequired(e => e.PRV_ESTADO_CIVIL)
                .HasForeignKey(e => e.PRV_ID_ESTADO_CIVIL_RESPONSAVEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_GRUPO>()
                .Property(e => e.PRV_NOME_GRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_GRUPO_TERAPEUTICO>()
                .Property(e => e.PRV_NOME_GRUPO_TERAPEUTICO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_GRUPO_TERAPEUTICO>()
                .Property(e => e.PRV_ENDEREÇO_GRUPO_TERAPEUTICO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_EXISTE_HISTORICO_DEPENDENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_FEZ_TRATAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_LOCAL_TRATAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_TEMPO_TRATAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_FAZ_USO_MEDICAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>()
                .Property(e => e.PRV_NOME_MEDICAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_MORADIA>()
                .HasMany(e => e.PRV_EDUCANDO1)
                .WithOptional(e => e.PRV_MORADIA1)
                .HasForeignKey(e => e.PRV_ID_MORADIA_RESPONSAVEL);

            modelBuilder.Entity<PRV_MORADORES_RESIDENCIA_EDUCANDO>()
                .Property(e => e.PRV_VACINACAO_EM_DIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_MORADORES_RESIDENCIA_EDUCANDO>()
                .Property(e => e.PRV_POSSUI_ACOMPANHAMENTO_MEDICO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_MORADORES_RESIDENCIA_EDUCANDO>()
                .Property(e => e.PRV_DESCRIACAO_POSSUI_ACOMPANHAMENTO_MEDICO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_MORADORES_RESIDENCIA_EDUCANDO>()
                .Property(e => e.PRV_PARTICIPA_DO_PROJETO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_MORADORES_RESIDENCIA_EDUCANDO>()
                .Property(e => e.PRV_DESCRIACAO_PARTICIPA_DO_PROJETO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_RENDA_FAMILIAR>()
                .Property(e => e.PRV_DESCRICAO_RENDA_FAMILIAR)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR>()
                .Property(e => e.DESCRICAO_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_TIPO_DE_FAMILIA>()
                .Property(e => e.PRV_DESCRICAO_TIPO_DE_FAMILIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_TIPO_DE_FAMILIA>()
                .HasMany(e => e.PRV_EDUCANDO)
                .WithRequired(e => e.PRV_TIPO_DE_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_TIPO_MORADIA>()
                .Property(e => e.PRV_DESCRICAO_TIPO_MORADIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_TIPO_MORADIA>()
                .HasMany(e => e.PRV_MORADIA)
                .WithRequired(e => e.PRV_TIPO_MORADIA)
                .HasForeignKey(e => e.PRV_ID_TIPO_MORADIA_RESPONSAVEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_NOME_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_CNPJ_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_CEP_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_ENDEREÇO_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_EMAIL_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_UNIDADE>()
                .Property(e => e.PRV_TELEFONE_UNIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_NOME_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_CPF_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_EMAIL_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_LOGIN_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_SENHA_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_CARGO_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_USUARIO>()
                .Property(e => e.PRV_SETOR_AREA_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_VIOLENCIA_NA_FAMILIA>()
                .Property(e => e.PRV_SOFREU_VIOLENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_VIOLENCIA_NA_FAMILIA>()
                .Property(e => e.PRV_MEDIDAS_TOMADAS)
                .IsUnicode(false);

            modelBuilder.Entity<PRV_VIOLENCIA_NA_FAMILIA>()
                .Property(e => e.PRV_ACIONOU_AUTORIDADES)
                .IsUnicode(false);
        }
    }
}
