/**
 * KiCadLauncherWin
 * Copyright 2014 Kenta IDA
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace KiCadLauncherWin
{
    static class Program
    {
        private const string RunKiCadBatchFilename = "RunKiCad.bat";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main()
        {
            string assemblyLocation = Assembly.GetEntryAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            string batchPath = Path.Combine(assemblyDirectory, RunKiCadBatchFilename);
            if (!File.Exists(batchPath))
            {
                string message = string.Format("{0} does not exist in directory {1}.", RunKiCadBatchFilename, assemblyDirectory);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(batchPath);
                startInfo.UseShellExecute = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
            }
            catch (Win32Exception e)
            {
                string message = string.Format("Could not launch KiCad.\n{0}", e.Message);
                return 1;
            }

            return 0;
        }
    }
}
