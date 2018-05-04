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
        Me.ckbFilmes = New System.Windows.Forms.CheckBox()
        Me.ckbScan = New System.Windows.Forms.CheckBox()
        Me.ckbPreservaExtensao = New System.Windows.Forms.CheckBox()
        Me.ckbProperCase = New System.Windows.Forms.CheckBox()
        Me.ckbPreprosicao = New System.Windows.Forms.CheckBox()
        Me.ckbArquivo = New System.Windows.Forms.CheckBox()
        Me.ckbPasta = New System.Windows.Forms.CheckBox()
        Me.pnlLog = New System.Windows.Forms.Panel()
        Me.pnlDataGrid = New System.Windows.Forms.Panel()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.mensagem = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.logErro = New System.Windows.Forms.ListBox()
        Me.de = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.para = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.incluir = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.btnCriaCbr.Location = New System.Drawing.Point(13, 9)
        Me.btnCriaCbr.Name = "btnCriaCbr"
        Me.btnCriaCbr.Size = New System.Drawing.Size(108, 23)
        Me.btnCriaCbr.TabIndex = 0
        Me.btnCriaCbr.Text = "Cria cbz"
        Me.ToolTip1.SetToolTip(Me.btnCriaCbr, "teste")
        Me.btnCriaCbr.UseVisualStyleBackColor = True
        '
        'btnDescompacta
        '
        Me.btnDescompacta.Location = New System.Drawing.Point(127, 9)
        Me.btnDescompacta.Name = "btnDescompacta"
        Me.btnDescompacta.Size = New System.Drawing.Size(108, 23)
        Me.btnDescompacta.TabIndex = 1
        Me.btnDescompacta.Text = "Descompacta"
        Me.btnDescompacta.UseVisualStyleBackColor = True
        '
        'log
        '
        Me.log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.log.FormattingEnabled = True
        Me.log.Location = New System.Drawing.Point(0, 0)
        Me.log.Name = "log"
        Me.log.ScrollAlwaysVisible = True
        Me.log.Size = New System.Drawing.Size(1069, 224)
        Me.log.TabIndex = 2
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.Panel1)
        Me.pnlbuttons.Controls.Add(Me.pnlCheckBox)
        Me.pnlbuttons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 0)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(1069, 89)
        Me.pnlbuttons.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
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
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(717, 89)
        Me.Panel1.TabIndex = 14
        '
        'btnCorrigeRoms
        '
        Me.btnCorrigeRoms.Location = New System.Drawing.Point(466, 38)
        Me.btnCorrigeRoms.Name = "btnCorrigeRoms"
        Me.btnCorrigeRoms.Size = New System.Drawing.Size(108, 23)
        Me.btnCorrigeRoms.TabIndex = 14
        Me.btnCorrigeRoms.Text = "Corrige No-Intro"
        Me.btnCorrigeRoms.UseVisualStyleBackColor = True
        '
        'btnCorrigeSerie
        '
        Me.btnCorrigeSerie.Location = New System.Drawing.Point(466, 9)
        Me.btnCorrigeSerie.Name = "btnCorrigeSerie"
        Me.btnCorrigeSerie.Size = New System.Drawing.Size(108, 23)
        Me.btnCorrigeSerie.TabIndex = 14
        Me.btnCorrigeSerie.Text = "Corrige Ep. Série"
        Me.btnCorrigeSerie.UseVisualStyleBackColor = True
        '
        'btnRomsDs
        '
        Me.btnRomsDs.Location = New System.Drawing.Point(355, 38)
        Me.btnRomsDs.Name = "btnRomsDs"
        Me.btnRomsDs.Size = New System.Drawing.Size(108, 23)
        Me.btnRomsDs.TabIndex = 13
        Me.btnRomsDs.Text = "Roms DS"
        Me.btnRomsDs.UseVisualStyleBackColor = True
        '
        'btnLegenda
        '
        Me.btnLegenda.Location = New System.Drawing.Point(240, 38)
        Me.btnLegenda.Name = "btnLegenda"
        Me.btnLegenda.Size = New System.Drawing.Size(108, 23)
        Me.btnLegenda.TabIndex = 12
        Me.btnLegenda.Text = "Arruma Legenda"
        Me.btnLegenda.UseVisualStyleBackColor = True
        '
        'btnCompacta
        '
        Me.btnCompacta.Location = New System.Drawing.Point(127, 38)
        Me.btnCompacta.Name = "btnCompacta"
        Me.btnCompacta.Size = New System.Drawing.Size(108, 23)
        Me.btnCompacta.TabIndex = 5
        Me.btnCompacta.Text = "Compacta Pastas"
        Me.btnCompacta.UseVisualStyleBackColor = True
        '
        'btnRenomeiaFotos
        '
        Me.btnRenomeiaFotos.Location = New System.Drawing.Point(355, 9)
        Me.btnRenomeiaFotos.Name = "btnRenomeiaFotos"
        Me.btnRenomeiaFotos.Size = New System.Drawing.Size(108, 23)
        Me.btnRenomeiaFotos.TabIndex = 7
        Me.btnRenomeiaFotos.Text = "Renomeia Fotos"
        Me.btnRenomeiaFotos.UseVisualStyleBackColor = True
        '
        'btnListaArquivos
        '
        Me.btnListaArquivos.Location = New System.Drawing.Point(241, 9)
        Me.btnListaArquivos.Name = "btnListaArquivos"
        Me.btnListaArquivos.Size = New System.Drawing.Size(108, 23)
        Me.btnListaArquivos.TabIndex = 7
        Me.btnListaArquivos.Text = "Lista Arquivos"
        Me.btnListaArquivos.UseVisualStyleBackColor = True
        '
        'btnRenomeia
        '
        Me.btnRenomeia.Location = New System.Drawing.Point(13, 38)
        Me.btnRenomeia.Name = "btnRenomeia"
        Me.btnRenomeia.Size = New System.Drawing.Size(108, 23)
        Me.btnRenomeia.TabIndex = 6
        Me.btnRenomeia.Text = "Renomeia"
        Me.btnRenomeia.UseVisualStyleBackColor = True
        '
        'pnlCheckBox
        '
        Me.pnlCheckBox.Controls.Add(Me.ckbNumerados)
        Me.pnlCheckBox.Controls.Add(Me.ckbRecursivo)
        Me.pnlCheckBox.Controls.Add(Me.ckbFilmes)
        Me.pnlCheckBox.Controls.Add(Me.ckbScan)
        Me.pnlCheckBox.Controls.Add(Me.ckbPreservaExtensao)
        Me.pnlCheckBox.Controls.Add(Me.ckbProperCase)
        Me.pnlCheckBox.Controls.Add(Me.ckbPreprosicao)
        Me.pnlCheckBox.Controls.Add(Me.ckbArquivo)
        Me.pnlCheckBox.Controls.Add(Me.ckbPasta)
        Me.pnlCheckBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCheckBox.Location = New System.Drawing.Point(717, 0)
        Me.pnlCheckBox.Name = "pnlCheckBox"
        Me.pnlCheckBox.Size = New System.Drawing.Size(352, 89)
        Me.pnlCheckBox.TabIndex = 13
        '
        'ckbNumerados
        '
        Me.ckbNumerados.AutoSize = True
        Me.ckbNumerados.Location = New System.Drawing.Point(163, 54)
        Me.ckbNumerados.Name = "ckbNumerados"
        Me.ckbNumerados.Size = New System.Drawing.Size(80, 17)
        Me.ckbNumerados.TabIndex = 12
        Me.ckbNumerados.Text = "Numerados"
        Me.ckbNumerados.UseVisualStyleBackColor = True
        '
        'ckbRecursivo
        '
        Me.ckbRecursivo.AutoSize = True
        Me.ckbRecursivo.Checked = True
        Me.ckbRecursivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbRecursivo.Location = New System.Drawing.Point(163, 37)
        Me.ckbRecursivo.Name = "ckbRecursivo"
        Me.ckbRecursivo.Size = New System.Drawing.Size(74, 17)
        Me.ckbRecursivo.TabIndex = 12
        Me.ckbRecursivo.Text = "Recursivo"
        Me.ckbRecursivo.UseVisualStyleBackColor = True
        '
        'ckbFilmes
        '
        Me.ckbFilmes.AutoSize = True
        Me.ckbFilmes.Location = New System.Drawing.Point(285, 3)
        Me.ckbFilmes.Name = "ckbFilmes"
        Me.ckbFilmes.Size = New System.Drawing.Size(55, 17)
        Me.ckbFilmes.TabIndex = 12
        Me.ckbFilmes.Text = "Filmes"
        Me.ckbFilmes.UseVisualStyleBackColor = True
        '
        'ckbScan
        '
        Me.ckbScan.AutoSize = True
        Me.ckbScan.Checked = True
        Me.ckbScan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbScan.Location = New System.Drawing.Point(164, 20)
        Me.ckbScan.Name = "ckbScan"
        Me.ckbScan.Size = New System.Drawing.Size(72, 17)
        Me.ckbScan.TabIndex = 12
        Me.ckbScan.Text = "Scan/HQ"
        Me.ckbScan.UseVisualStyleBackColor = True
        '
        'ckbPreservaExtensao
        '
        Me.ckbPreservaExtensao.AutoSize = True
        Me.ckbPreservaExtensao.Checked = True
        Me.ckbPreservaExtensao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPreservaExtensao.Location = New System.Drawing.Point(164, 3)
        Me.ckbPreservaExtensao.Name = "ckbPreservaExtensao"
        Me.ckbPreservaExtensao.Size = New System.Drawing.Size(115, 17)
        Me.ckbPreservaExtensao.TabIndex = 12
        Me.ckbPreservaExtensao.Text = "Preserva Extensão"
        Me.ckbPreservaExtensao.UseVisualStyleBackColor = True
        '
        'ckbProperCase
        '
        Me.ckbProperCase.AutoSize = True
        Me.ckbProperCase.Checked = True
        Me.ckbProperCase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbProperCase.Location = New System.Drawing.Point(16, 3)
        Me.ckbProperCase.Name = "ckbProperCase"
        Me.ckbProperCase.Size = New System.Drawing.Size(141, 17)
        Me.ckbProperCase.TabIndex = 8
        Me.ckbProperCase.Text = "Primeira Letra Maiúscula"
        Me.ckbProperCase.UseVisualStyleBackColor = True
        '
        'ckbPreprosicao
        '
        Me.ckbPreprosicao.AutoSize = True
        Me.ckbPreprosicao.Checked = True
        Me.ckbPreprosicao.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPreprosicao.Location = New System.Drawing.Point(16, 20)
        Me.ckbPreprosicao.Name = "ckbPreprosicao"
        Me.ckbPreprosicao.Size = New System.Drawing.Size(126, 17)
        Me.ckbPreprosicao.TabIndex = 9
        Me.ckbPreprosicao.Text = "Preserva preprosição"
        Me.ckbPreprosicao.UseVisualStyleBackColor = True
        '
        'ckbArquivo
        '
        Me.ckbArquivo.AutoSize = True
        Me.ckbArquivo.Checked = True
        Me.ckbArquivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbArquivo.Location = New System.Drawing.Point(16, 54)
        Me.ckbArquivo.Name = "ckbArquivo"
        Me.ckbArquivo.Size = New System.Drawing.Size(119, 17)
        Me.ckbArquivo.TabIndex = 11
        Me.ckbArquivo.Text = "Renomear Arquivos"
        Me.ckbArquivo.UseVisualStyleBackColor = True
        '
        'ckbPasta
        '
        Me.ckbPasta.AutoSize = True
        Me.ckbPasta.Checked = True
        Me.ckbPasta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPasta.Location = New System.Drawing.Point(16, 37)
        Me.ckbPasta.Name = "ckbPasta"
        Me.ckbPasta.Size = New System.Drawing.Size(122, 17)
        Me.ckbPasta.TabIndex = 10
        Me.ckbPasta.Text = "Renomear Diretórios"
        Me.ckbPasta.UseVisualStyleBackColor = True
        '
        'pnlLog
        '
        Me.pnlLog.Controls.Add(Me.log)
        Me.pnlLog.Controls.Add(Me.logErro)
        Me.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLog.Location = New System.Drawing.Point(0, 211)
        Me.pnlLog.Name = "pnlLog"
        Me.pnlLog.Size = New System.Drawing.Size(1069, 332)
        Me.pnlLog.TabIndex = 5
        '
        'pnlDataGrid
        '
        Me.pnlDataGrid.Controls.Add(Me.dg)
        Me.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDataGrid.Location = New System.Drawing.Point(0, 89)
        Me.pnlDataGrid.Name = "pnlDataGrid"
        Me.pnlDataGrid.Size = New System.Drawing.Size(1069, 122)
        Me.pnlDataGrid.TabIndex = 6
        '
        'dg
        '
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.de, Me.para, Me.incluir})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Name = "dg"
        Me.dg.Size = New System.Drawing.Size(1069, 122)
        Me.dg.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mensagem, Me.pBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 543)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1069, 22)
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'mensagem
        '
        Me.mensagem.AutoSize = False
        Me.mensagem.Name = "mensagem"
        Me.mensagem.Size = New System.Drawing.Size(550, 17)
        Me.mensagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mensagem.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'pBar
        '
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(300, 16)
        Me.pBar.Step = 1
        Me.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'logErro
        '
        Me.logErro.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.logErro.FormattingEnabled = True
        Me.logErro.Location = New System.Drawing.Point(0, 224)
        Me.logErro.Name = "logErro"
        Me.logErro.ScrollAlwaysVisible = True
        Me.logErro.Size = New System.Drawing.Size(1069, 108)
        Me.logErro.TabIndex = 3
        Me.logErro.Visible = False
        '
        'de
        '
        Me.de.HeaderText = "De"
        Me.de.Name = "de"
        Me.de.Width = 280
        '
        'para
        '
        Me.para.HeaderText = "Para"
        Me.para.Name = "para"
        Me.para.Width = 280
        '
        'incluir
        '
        Me.incluir.HeaderText = "Incluir"
        Me.incluir.Name = "incluir"
        Me.incluir.Width = 280
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 565)
        Me.Controls.Add(Me.pnlLog)
        Me.Controls.Add(Me.pnlDataGrid)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
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
End Class
