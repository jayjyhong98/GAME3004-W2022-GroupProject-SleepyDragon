//*********************************************************************************************************************************************
// Author: Mariam Ogunlesi
//
// Last Modified: January 28, 2022
//  
// Description: This holds the position and orientation of an object
//
//***************************************************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class TransformLite
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public float orientationX;
    public float orientationY;
    public float orientationZ;

    public TransformLite()
    {
        positionX = 0;
        positionY = 0;
        positionZ = 0;
        orientationX = 0;
        orientationY = 0;
        orientationZ = 0;
    }

    public TransformLite(float _insertPosX, float _insertPosY, float _insertPosZ, float _insertRotX, float _insertRotY, float _insertRotZ)
    {
        positionX = _insertPosX;
        positionY = _insertPosY;
        positionZ = _insertPosZ;
        orientationX = _insertRotX;
        orientationY = _insertRotY;
        orientationZ = _insertRotZ;
    }
}
