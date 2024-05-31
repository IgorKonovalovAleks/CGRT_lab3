using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Windows.Forms;

namespace CGRT_lab3
{
  public partial class Form1 : Form
  {
    View view;
    bool loaded = false;

    public Form1()
    {
      InitializeComponent();
      view = new View();
    }

    private void glControl1_Load(object sender, EventArgs e)
    {
      loaded = true;
      GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
      view.Setup(glControl1.Width, glControl1.Height);
      view.InitShaders();
      view.DrawQuad();
      int MatID1 = GL.GetUniformLocation(view.BasicProgramID, "MaterialId");
      GL.Uniform1(MatID1, trackBar1.Value);
      int MatID2 = GL.GetUniformLocation(view.BasicProgramID, "RayTracingDepth");
      GL.Uniform1(MatID2, trackBar2.Value);
    }

    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
      if (loaded)
      {
        view.ReDraw();
        glControl1.SwapBuffers();
        GL.UseProgram(0);
      }
    }

    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
      view.DrawQuad();
      int MatID = GL.GetUniformLocation(view.BasicProgramID, "MaterialId");
      GL.Uniform1(MatID, trackBar1.Value);
      view.ReDraw();
      glControl1.SwapBuffers();
      GL.UseProgram(0);
    }

    private void trackBar2_ValueChanged(object sender, EventArgs e)
    {
      view.DrawQuad();
      int MatID2 = GL.GetUniformLocation(view.BasicProgramID, "RayTracingDepth");
      GL.Uniform1(MatID2, trackBar2.Value);
      view.ReDraw();
      glControl1.SwapBuffers();
      GL.UseProgram(0);
    }
  }
  class View
  {
    public int BasicProgramID;
    private int BasicVertexShader;
    private int BasicFragmentShader;
    private Vector3[] vertdata;
    private int vbo_position;
    private int attribute_vpos;
    private int uniform_pos;
    private int uniform_aspect;
    private Vector3 campos;
    private double aspect;

    private void loadShader(String filename, ShaderType type, int program, out int address)
    {
      address = GL.CreateShader(type);
      using (System.IO.StreamReader sr = new StreamReader(filename))
      {
        GL.ShaderSource(address, sr.ReadToEnd());
      }
      GL.CompileShader(address);
      GL.AttachShader(program, address);
      Console.WriteLine(GL.GetShaderInfoLog(address));
    }

    public void InitShaders()
    {
      BasicProgramID = GL.CreateProgram(); // создание объекта программы
      loadShader("..\\..\\rt.vert", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);

      loadShader("..\\..\\rt.frag", ShaderType.FragmentShader, BasicProgramID,

      out BasicFragmentShader);
      GL.LinkProgram(BasicProgramID);
      // Проверяем успех компоновки
      int status = 0;
      GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out status);
      Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));
    }

    public void DrawQuad()
    {
      vertdata = new Vector3[] {
            new Vector3(-1f, -1f, 0f),
            new Vector3( 1f, -1f, 0f),
            new Vector3( 1f, 1f, 0f),
            new Vector3(-1f, 1f, 0f) };
      GL.GenBuffers(1, out vbo_position);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
      GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length *
      Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
      GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);
      GL.Uniform3(uniform_pos, campos);
      GL.Uniform1(uniform_aspect, aspect);
      GL.UseProgram(BasicProgramID);
      GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }

    public void ReDraw()
    {
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      GL.Enable(EnableCap.DepthTest);
      GL.EnableVertexAttribArray(attribute_vpos);
      GL.DrawArrays(PrimitiveType.Quads, 0, 4);
      GL.DisableVertexAttribArray(attribute_vpos);
    }

    public void Setup(int w, int h)
    {
      string str = GL.GetString(StringName.ShadingLanguageVersion);
      GL.ClearColor(Color.DarkGray);
      GL.ShadeModel(ShadingModel.Smooth);

      Matrix4 perspMat = Matrix4.CreatePerspectiveFieldOfView(
          MathHelper.PiOver4, w / (float)h, 1, 64);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadMatrix(ref perspMat);

      Matrix4 viewMat = Matrix4.LookAt(0, 0, 3, 0, 0, 0, 0, 1, 0);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref viewMat);
    }

  }
}
