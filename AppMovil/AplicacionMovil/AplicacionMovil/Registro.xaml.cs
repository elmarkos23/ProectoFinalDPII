﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicacionMovil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		Modelos.AsistenciaDetalle AsistenciaDetalle = new Modelos.AsistenciaDetalle();
		public Registro ()
		{
			InitializeComponent ();
		}
	}
}