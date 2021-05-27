using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;
using WebAssemblyTestApp.Model;

namespace WebAssemblyTestApp.Service
{
    public class BuilngEventHandler : IBuilngEventHandler
    {
        public string Message { get; set; }
        private bool isMoving = false;
        private int mouseDragStartPositionX;
        private int mouseDragStartPositionY;
        private int buildingStartPositionX;
        private int buildingStartPositionY;

        public async void OnMouseDownHandle(MouseEventArgs e, Building building)
        {
            if (!building.Selected)
            {
                building.Selected = true;
                isMoving = true;
                mouseDragStartPositionX = (int)e.ClientX;
                mouseDragStartPositionY = (int)e.ClientY;
                buildingStartPositionX = building.X;
                buildingStartPositionY = building.Y;
                Message = $"({building.X}, {building.Y}), {mouseDragStartPositionX - (int)e.ClientX}";
            }
            else
            {
                building.Selected = false;
            }
        }

        public async void OnMouseMoveHandle(MouseEventArgs e, Building building)
        {
            if (isMoving && building.Selected)
            {
                building.X = buildingStartPositionX + ((int)e.ClientX - mouseDragStartPositionX);
                building.Y = buildingStartPositionY + ((int)e.ClientY - mouseDragStartPositionY);
                Message = $"({building.X}, {building.Y}), {mouseDragStartPositionX - (int)e.ClientX}";
            }
        }

        public async void OnMouseUpHandle(MouseEventArgs e, Building building)
        {
            isMoving = false;
        }

        public async void OnMouseOutHandle(MouseEventArgs e, Building building)
        {
        }

        public async void OnMouseDownHandleSort(List<Building> buildingList)
        {
            buildingList.Sort((x, y) => { return x.Selected.CompareTo(y.Selected); });
        }

        public void RotateClockwise(List<Building> buildingList)
        {
            var toRotate = buildingList.Where((x) => x.Selected == true);
            foreach (var rotate in toRotate)
            {
                rotate.Rotation += 90;
            }
        }
    }
}