<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.btnCriaCbr = New System.Windows.Forms.Button()
        Me.btnDescompacta = New System.Windows.Forms.Button()
        Me.log = New System.Windows.Forms.ListBox()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConvertPDF = New System.Windows.Forms.Button()
        Me.btnCriarPastas = New System.Windows.Forms.Button()
        Me.btnPasta = New System.Windows.Forms.Button()
        Me.btnCorrigeRoms = New System.Windows.Forms.Button()
        Me.btnCorrigeSerie = New System.Windows.Forms.Button()
        Me.btnRomsDs = New System.Windows.Forms.Button()
        Me.btnLegenda = New System.Windows.Forms.Button()
        Me.btnCompacta = New System.Windows.Forms.Button()
        Me.btnRenomeiaFotos = New System.Windows.Forms.Button()
        Me.btnListaArquivos = New System.Windows.Forms.Button()
        Me.btnRenomeia = New System.Windows.Forms.Button()
        Me.pnlCheckBox = New System.Windows.Forms.Panel()
        Me.ckbNumerados = New System.Windows.Forms.CheckBox()
        Me.ckbRecursivo = New System.Windows.Forms.CheckBox()
        Me.cbkMudaExt = New System.Windows.Forms.CheckBox()
        Me.ckbFilmes = New System.Windows.Forms.CheckBox()
        Me.ckbScan = New System.Windows.Forms.CheckBox()
        Me.ckbPreservaExtensao = New System.Windows.Forms.CheckBox()
        Me.ckbProperCase = New System.Windows.Forms.CheckBox()
        Me.ckbPreprosicao = New System.Windows.Forms.CheckBox()
        Me.ckbArquivo = New System.Windows.Forms.CheckBox()
        Me.ckbPasta = New System.Windows.Forms.CheckBox()
        Me.pnlLog = New System.Windows.Forms.Panel()
        Me.logErro = New System.Windows.Forms.ListBox()
        Me.pnlDataGrid = New System.Windows.Forms.Panel()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.de = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.para = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.incluir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.mensagem = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dlgFolderSelect = New System.Windows.Forms.FolderBrowserDialog()
        Me.bwMakePdf = New System.ComponentModel.BackgroundWorker()
        Me.ckbRemoverNumerados = New System.Windows.Forms.CheckBox()
        Me.pnlbuttons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCheckBox.SuspendLayout()
        Me.pnlLog.SuspendLayout()
        Me.pnlDataGrid.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCriaCbr
        '
        Me.btnCriaCbr.Enabled = False
        Me.btnCriaCbr.Location = New System.Drawing.Point(17, 11)
        Me.btnCriaCbr.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCriaCbr.Name = "btnCriaCbr"
        Me.btnCriaCbr.Size = New System.Drawing.Size(144, 28)
        Me.btnCriaCbr.TabIndex = 0
        Me.btnCriaCbr.Text = "Cria cbz"
        Me.ToolTip1.SetToolTip(Me.btnCriaCbr, "teste")
        Me.btnCriaCbr.UseVisualStyleBackColor = True
        '
        'btnDescompacta
        '
        Me.btnDescompacta.Enabled = False
        Me.btnDescompacta.Location = New System.Drawing.Point(169, 11)
        Me.btnDescompacta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDescompacta.Name = "btnDescompacta"
        Me.btnDescompacta.Size = New System.Drawing.Size(144, 28)
        Me.btnDescompacta.TabIndex = 1
        Me.btnDescompacta.Text = "Descompacta"
        Me.btnDescompacta.UseVisualStyleBackColor = True
        '
        'log
        '
        Me.log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.log.FormattingEnabled = True
        Me.log.ItemHeight = 16
        Me.log.Location = New System.Drawing.Point(0, 0)
        Me.log.Margin = New System.Windows.Forms.Padding(4)
        Me.log.Name = "log"
        Me.log.ScrollAlwaysVisible = True
        Me.log.Size = New System.Drawing.Size(1425, 269)
        Me.log.TabIndex = 2
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.Panel1)
        Me.pnlbuttons.Controls.Add(Me.pnlCheckBox)
        Me.pnlbuttons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 0)
        Me.pnlbuttons.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(1425, 119)
        Me.pnlbuttons.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.btnConvertPDF)
        Me.Panel1.Controls.Add(Me.btnCriarPastas)
        Me.Panel1.Controls.Add(Me.btnPasta)
        Me.Panel1.Controls.Add(Me.btnCorrigeRoms)
        Me.Panel1.Controls.Add(Me.btnCorrigeSerie)
        Me.Panel1.Controls.Add(Me.btnRomsDs)
        Me.Panel1.Controls.Add(Me.btnCriaCbr)
        Me.Panel1.Controls.Add(Me.btnDescompacta)
        Me.Panel1.Controls.Add(Me.btnLegenda)
        Me.Panel1.Controls.Add(Me.btnCompacta)
        Me.Panel1.Controls.Add(Me.btnRenomeiaFotos)
        Me.Panel1.Controls.Add(Me.btnListaArquivos)
        Me.Panel1.Controls.Add(Me.btnRenomeia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(910, 119)
        Me.Panel1.TabIndex = 14
        '
        'btnConvertPDF
        '
        Me.btnConvertPDF.Location = New System.Drawing.Point(17, 81)
        Me.btnConvertPDF.Name = "btnConvertPDF"
        Me.btnConvertPDF.Size = New System.Drawing.Size(144, 28)
        Me.btnConvertPDF.TabIndex = 8
        Me.btnConvertPDF.Text = "Converter PDF"
        Me.btnConvertPDF.UseVisualStyleBackColor = True
        '
        'btnCriarPastas
        '
        Me.btnCriarPastas.Location = New System.Drawing.Point(773, 46)
        Me.btnCriarPastas.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCriarPastas.Name = "btnCriarPastas"
        Me.btnCriarPastas.Size = New System.Drawing.Size(119, 28)
        Me.btnCriarPastas.TabIndex = 15
        Me.btnCriarPastas.Text = "Criar Pasta"
        Me.btnCriarPastas.UseVisualStyleBackColor = True
        '
        'btnPasta
        '
        Me.btnPasta.Location = New System.Drawing.Point(773, 11)
        Me.btnPasta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPasta.Name = "btnPasta"
        Me.btnPasta.Size = New System.Drawing.Size(119, 28)
        Me.btnPasta.TabIndex = 15
        Me.btnPasta.Text = "Pasta"
        Me.btnPasta.UseVisualStyleBackColor = True
        '
        'btnCorrigeRoms
        '
        Me.btnCorrigeRoms.Location = New System.Drawing.Point(621, 46)
        Me.btnCorrigeRoms.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCorrigeRoms.Name = "btnCorrigeRoms"
        Me.btnCorrigeRoms.Size = New System.Drawing.Size(144, 28)
        Me.btnCorrigeRoms.TabIndex = 14
        Me.btnCorrigeRoms.Text = "Corrige No-Intro"
        Me.btnCorrigeRoms.UseVisualStyleBackColor = True
        '
        'btnCorrigeSerie
        '
        Me.btnCorrigeSerie.Location = New System.Drawing.Point(621, 11)
        Me.btnCorrigeSerie.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCorrigeSerie.Name = "btnCorrigeSerie"
        Me.btnCorrigeSerie.Size = New System.Drawing.Size(144, 28)
        Me.btnCorrigeSerie.TabIndex = 14
        Me.btnCorrigeSerie.Text = "Corrige Ep. Série"
        Me.btnCorrigeSerie.UseVisualStyleBackColor = True
        '
        'btnRomsDs
        '
        Me.btnRomsDs.Location = New System.Drawing.Point(473, 46)
        Me.btnRomsDs.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRomsDs.Name = "btnRomsDs"
        Me.btnRomsDs.Size = New System.Drawing.Size(144, 28)
        Me.btnRomsDs.TabIndex = 13
        Me.btnRomsDs.Text = "Roms DS"
        Me.btnRomsDs.UseVisualStyleBackColor = True
        '
        'btnLegenda
        '
        Me.btnLegenda.Location = New System.Drawing.Point(320, 46)
        Me.btnLegenda.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLegenda.Name = "btnLegenda"
        Me.btnLegenda.Size = New System.Drawing.Size(144, 28)
        Me.btnLegenda.TabIndex = 12
        Me.btnLegenda.Text = "Arruma Legenda"
        Me.btnLegenda.UseVisualStyleBackColor = True
        '
        'btnCompacta
        '
        Me.btnCompacta.Enabled = False
        Me.btnCompacta.Location = New System.Drawing.Point(169, 46)
        Me.btnCompacta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCompacta.Name = "btnCompacta"
        Me.btnCompacta.Size = New System.Drawing.Size(144, 28)
        Me.btnCompacta.TabIndex = 5
        Me.btnCompacta.Text = "Compacta Pastas"
        Me.btnCompacta.UseVisualStyleBackColor = True
        '
        'btnRenomeiaFotos
        '
        Me.btnRenomeiaFotos.Location = New System.Drawing.Point(473, 11)
        Me.btnRenomeiaFotos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRenomeiaFotos.Name = "btnRenomeiaFotos"
        Me.btnRenomeiaFotos.Size = New System.Drawing.Size(144, 28)
        Me.btnRenomeiaFotos.TabIndex = 7
        Me.btnRenomeiaFotos.Text = "Renomeia Fotos"
        Me.btnRenomeiaFotos.UseVisualStyleBackColor = True
        '
        'btnListaArquivos
        '
        Me.btnListaArquivos.Location = New System.Drawing.Point(321, 11)
        Me.btnListaArquivos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnListaArquivos.Name = "btnListaArquivos"
        Me.btnListaArquivos.Size = New System.Drawing.Size(144, 28)
        Me.btnListaArquivos.TabIndex = 7
        Me.btnListaArquivos.Text = "Lista Arquivos"
        Me.btnListaArquivos.UseVisualStyleBackColor = True
        '
        'btnRenomeia
        '
        Me.btnRenomeia.Location = New System.Drawing.Point(17, 46)
        Me.btnRenomeia.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRenomeia.Name = "btnRenomeia"
        Me.btnRenomeia.Size = New System.Drawing.Size(144, 28)
        Me.btnRenomeia.TabIndex = 6
        Me.btnRenomeia.Text = "Renomeia"
        Me.btnRenomeia.UseVisualStyleBackColor = True
        '
        'pnlCheckBox
        '
        Me.pnlCheckBox.Controls.Add(Me.ckbRemoverNumerados)
        Me.pnlCheckBox.Controls.Add(Me.ckbNumerados)
        Me.pnlCheckBox.Controls.Add(Me.ckbRecursivo)
        Me.pnlCheckBox.Controls.Add(Me.cbkMudaExt)
        Me.pnlCheckBox.Controls.Add(Me.ckbFilmes)
        Me.pnlCheckBox.Controls.Add(Me.ckbScan)
        Me.pnlCheckBox.Controls.Add(Me.ckbPreservaExtensao)
        Me.pnlCheckBox.Controls.Add(Me.ckbProperCase)
        Me.pnlCheckBox.Controls.Add(Me.ckbPreprosicao)
        Me.pnlCheckBox.Controls.Add(Me.ckbArquivo)
        Me.pnlCheckBox.Controls.Add(Me.ckbPasta)
        Me.pnlCheckBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCheckBox.Location = New System.Drawing.Point(910, 0)
        Me.pnlCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCheckBox.Name = "pnlCheckBox"
        Me.pnlCheckBox.Size = New System.Drawing.Size(515, 119)
        Me.pnlCheckBox.TabIndex = 13
        '
        'ckbNumerados
        '
        Me.ckbNumerados.AutoSize = True
        Me.ckbNumerados.Location = New System.Drawing.Point(217, 66)
        Me.ckbNumerados.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbNumerados.Name = "ckbNumerados"
        Me.ckbNumerados.Size = New System.Drawing.Size(100, 20)
        Me.ckbNumerados.TabIndex = 12
        Me.ckbNumerados.Text = "Numerados"
        Me.ckbNumerados.UseVisualStyleBackColor = True
        '
        'ckbRecursivo
        '
        Me.ckbRecursivo.AutoSize = True
        Me.ckbRecursivo.Checked = True
        Me.ckbRecursivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbRecursivo.Location = New System.Drawing.Point(217, 46)
        Me.ckbRecursivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbRecursivo.Name = "ckbRecursivo"
        Me.ckbRecursivo.Size = New System.Drawing.Size(90, 20)
        Me.ckbRecursivo.TabIndex = 12
        Me.ckbRecursivo.Text = "Recursivo"
        Me.ckbRecursivo.UseVisualStyleBackColor = True
        '
        'cbkMudaExt
        '
        Me.cbkMudaExt.AutoSize = True
        Me.cbkMudaExt.Location = New System.Drawing.Point(380, 25)
        Me.cbkMudaExt.Margin = New System.Windows.Forms.Padding(4)
        Me.cbkMudaExt.Name = "cbkMudaExt"
        Me.cbkMudaExt.Size = New System.Drawing.Size(81, 20)
        Me.cbkMudaExt.TabIndex = 12
        Me.cbkMudaExt.Text = "rar -> cbr"
        Me.cbkMudaExt.UseVisualStyleBackColor = True
        '
        'ckbFilmes
        '
        Me.ckbFilmes.AutoSize = True
        Me.ckbFilmes.Location = New System.Drawing.Point(380, 4)
        Me.ckbFilmes.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbFilmes.Name = "ckbFilmes"
        Me.ckbFilmes.Size = New System.Drawing.Size(69, 20)
        Me.ckbFilmes.TabIndex = 12
        Me.ckbFilmes.Text = "Filmes"
        Me.ckbFilmes.UseVisualStyleBackColor = True
        '
        'ckbScan
        '
        Me.ckbScan.AutoSize = True
        Me.ckbScan.Checked = True
        Me.ckbScan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbScan.Location = New System.Drawing.Point(219, 25)
        Me.ckbScan.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbScan.Name = "ckbScan"
        Me.ckbScan.Size = New System.Drawing.Size(84, 20)
        Me.ckbScan.TabIndex = 12
        Me.ckbScan.Text = "Scan/HQ"
        Me.ckbScan.UseVisualStyleBackColor = True
        '
        'ckbPreservaExtensao
        '
        Me.ckbPreservaExtensao.AutoSize = True
        Me.ckbPreservaExtensao.Checked = True
        Me.ckbPreservaExtensao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPreservaExtensao.Location = New System.Drawing.Point(219, 4)
        Me.ckbPreservaExtensao.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbPreservaExtensao.Name = "ckbPreservaExtensao"
        Me.ckbPreservaExtensao.Size = New System.Drawing.Size(143, 20)
        Me.ckbPreservaExtensao.TabIndex = 12
        Me.ckbPreservaExtensao.Text = "Preserva Extensão"
        Me.ckbPreservaExtensao.UseVisualStyleBackColor = True
        '
        'ckbProperCase
        '
        Me.ckbProperCase.AutoSize = True
        Me.ckbProperCase.Checked = True
        Me.ckbProperCase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbProperCase.Location = New System.Drawing.Point(21, 4)
        Me.ckbProperCase.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbProperCase.Name = "ckbProperCase"
        Me.ckbProperCase.Size = New System.Drawing.Size(176, 20)
        Me.ckbProperCase.TabIndex = 8
        Me.ckbProperCase.Text = "Primeira Letra Maiúscula"
        Me.ckbProperCase.UseVisualStyleBackColor = True
        '
        'ckbPreprosicao
        '
        Me.ckbPreprosicao.AutoSize = True
        Me.ckbPreprosicao.Checked = True
        Me.ckbPreprosicao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPreprosicao.Location = New System.Drawing.Point(21, 25)
        Me.ckbPreprosicao.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbPreprosicao.Name = "ckbPreprosicao"
        Me.ckbPreprosicao.Size = New System.Drawing.Size(160, 20)
        Me.ckbPreprosicao.TabIndex = 9
        Me.ckbPreprosicao.Text = "Preserva preprosição"
        Me.ckbPreprosicao.UseVisualStyleBackColor = True
        '
        'ckbArquivo
        '
        Me.ckbArquivo.AutoSize = True
        Me.ckbArquivo.Checked = True
        Me.ckbArquivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbArquivo.Location = New System.Drawing.Point(21, 66)
        Me.ckbArquivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbArquivo.Name = "ckbArquivo"
        Me.ckbArquivo.Size = New System.Drawing.Size(149, 20)
        Me.ckbArquivo.TabIndex = 11
        Me.ckbArquivo.Text = "Renomear Arquivos"
        Me.ckbArquivo.UseVisualStyleBackColor = True
        '
        'ckbPasta
        '
        Me.ckbPasta.AutoSize = True
        Me.ckbPasta.Checked = True
        Me.ckbPasta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPasta.Location = New System.Drawing.Point(21, 46)
        Me.ckbPasta.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbPasta.Name = "ckbPasta"
        Me.ckbPasta.Size = New System.Drawing.Size(154, 20)
        Me.ckbPasta.TabIndex = 10
        Me.ckbPasta.Text = "Renomear Diretórios"
        Me.ckbPasta.UseVisualStyleBackColor = True
        '
        'pnlLog
        '
        Me.pnlLog.Controls.Add(Me.log)
        Me.pnlLog.Controls.Add(Me.logErro)
        Me.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLog.Location = New System.Drawing.Point(0, 269)
        Me.pnlLog.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlLog.Name = "pnlLog"
        Me.pnlLog.Size = New System.Drawing.Size(1425, 401)
        Me.pnlLog.TabIndex = 5
        '
        'logErro
        '
        Me.logErro.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.logErro.FormattingEnabled = True
        Me.logErro.ItemHeight = 16
        Me.logErro.Location = New System.Drawing.Point(0, 269)
        Me.logErro.Margin = New System.Windows.Forms.Padding(4)
        Me.logErro.Name = "logErro"
        Me.logErro.ScrollAlwaysVisible = True
        Me.logErro.Size = New System.Drawing.Size(1425, 132)
        Me.logErro.TabIndex = 3
        Me.logErro.Visible = False
        '
        'pnlDataGrid
        '
        Me.pnlDataGrid.Controls.Add(Me.dg)
        Me.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDataGrid.Location = New System.Drawing.Point(0, 119)
        Me.pnlDataGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlDataGrid.Name = "pnlDataGrid"
        Me.pnlDataGrid.Size = New System.Drawing.Size(1425, 150)
        Me.pnlDataGrid.TabIndex = 6
        '
        'dg
        '
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.de, Me.para, Me.incluir})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Margin = New System.Windows.Forms.Padding(4)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersWidth = 51
        Me.dg.Size = New System.Drawing.Size(1425, 150)
        Me.dg.TabIndex = 0
        '
        'de
        '
        Me.de.HeaderText = "De"
        Me.de.MinimumWidth = 6
        Me.de.Name = "de"
        Me.de.Width = 280
        '
        'para
        '
        Me.para.HeaderText = "Para"
        Me.para.MinimumWidth = 6
        Me.para.Name = "para"
        Me.para.Width = 280
        '
        'incluir
        '
        Me.incluir.HeaderText = "Incluir"
        Me.incluir.MinimumWidth = 6
        Me.incluir.Name = "incluir"
        Me.incluir.Width = 280
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mensagem, Me.pBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 670)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1425, 25)
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'mensagem
        '
        Me.mensagem.AutoSize = False
        Me.mensagem.Name = "mensagem"
        Me.mensagem.Size = New System.Drawing.Size(550, 19)
        Me.mensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mensagem.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'pBar
        '
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(400, 17)
        Me.pBar.Step = 1
        Me.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'bwMakePdf
        '
        Me.bwMakePdf.WorkerReportsProgress = True
        Me.bwMakePdf.WorkerSupportsCancellation = True
        '
        'ckbRemoverNumerados
        '
        Me.ckbRemoverNumerados.AutoSize = True
        Me.ckbRemoverNumerados.Location = New System.Drawing.Point(21, 86)
        Me.ckbRemoverNumerados.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbRemoverNumerados.Name = "ckbRemoverNumerados"
        Me.ckbRemoverNumerados.Size = New System.Drawing.Size(159, 20)
        Me.ckbRemoverNumerados.TabIndex = 13
        Me.ckbRemoverNumerados.Text = "Remover Numerados"
        Me.ckbRemoverNumerados.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1425, 695)
        Me.Controls.Add(Me.pnlLog)
        Me.Controls.Add(Me.pnlDataGrid)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Principal"
        Me.Text = "Tools"
        Me.pnlbuttons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCheckBox.ResumeLayout(False)
        Me.pnlCheckBox.PerformLayout()
        Me.pnlLog.ResumeLayout(False)
        Me.pnlDataGrid.ResumeLayout(False)
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCriaCbr As System.Windows.Forms.Button
    Friend WithEvents btnDescompacta As System.Windows.Forms.Button
    Friend WithEvents log As System.Windows.Forms.ListBox
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnCompacta As System.Windows.Forms.Button
    Friend WithEvents btnRenomeia As System.Windows.Forms.Button
    Friend WithEvents pnlLog As System.Windows.Forms.Panel
    Friend WithEvents pnlDataGrid As System.Windows.Forms.Panel
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents btnListaArquivos As System.Windows.Forms.Button
    Friend WithEvents ckbProperCase As System.Windows.Forms.CheckBox
    Friend WithEvents ckbPreprosicao As System.Windows.Forms.CheckBox
    Friend WithEvents ckbArquivo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbPasta As System.Windows.Forms.CheckBox
    Friend WithEvents btnLegenda As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlCheckBox As System.Windows.Forms.Panel
    Friend WithEvents ckbPreservaExtensao As System.Windows.Forms.CheckBox
    Friend WithEvents btnRenomeiaFotos As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents mensagem As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ckbScan As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnRomsDs As System.Windows.Forms.Button
    Friend WithEvents btnCorrigeSerie As System.Windows.Forms.Button
    Friend WithEvents btnCorrigeRoms As System.Windows.Forms.Button
    Friend WithEvents ckbRecursivo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbNumerados As CheckBox
    Friend WithEvents ckbFilmes As CheckBox
    Friend WithEvents logErro As ListBox
    Friend WithEvents de As DataGridViewTextBoxColumn
    Friend WithEvents para As DataGridViewTextBoxColumn
    Friend WithEvents incluir As DataGridViewTextBoxColumn
    Friend WithEvents cbkMudaExt As CheckBox
    Friend WithEvents btnPasta As Button
    Friend WithEvents btnCriarPastas As Button
    Friend WithEvents btnConvertPDF As Button
    Friend WithEvents dlgFolderSelect As FolderBrowserDialog
    Friend WithEvents bwMakePdf As System.ComponentModel.BackgroundWorker
    Friend WithEvents ckbRemoverNumerados As CheckBox
End Class
