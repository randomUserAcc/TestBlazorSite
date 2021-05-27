using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using WebAssemblyTestApp.Model;

namespace WebAssemblyTestApp.Service
{
    public interface IBuilngEventHandler
    {
        public string Message { get; set; }

        void OnMouseMoveHandle(MouseEventArgs e, Building building);

        void OnMouseDownHandle(MouseEventArgs e, Building building);

        void OnMouseOutHandle(MouseEventArgs e, Building building);

        void OnMouseUpHandle(MouseEventArgs e, Building building);

        void OnMouseDownHandleSort(List<Building> buildingList);

        void RotateClockwise(List<Building> buildingList);
    }
}