using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：LookAt2D  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/3 19:34:35
// ================================
namespace Assets.JackCheng.Euler
{
    public class LookAt2D : MonoBehaviour
    {

        [SerializeField]
        private Transform target;
        [SerializeField]
        [Range(0, 360)]
        private float tempAnglesX;

        [SerializeField]
        [Range(0, 360)]
        private float tempAnglesY;

        [SerializeField]
        [Range(0, 360)]
        private float tempAnglesZ;
        void Update()
        {

            //Quaternion tempQua = this.transform.rotation;
            //tempQua.eulerAngles = new Vector3(tempAnglesX, tempAnglesY, tempAnglesZ);
            //this.transform.rotation = tempQua;

            //return;


            LookAtTarget();
        }

        private void LookAtTarget()
        {
            Vector2 offset = (target.transform.position - this.transform.position).normalized;

            float moveVx = offset.x;
            float moveVy = offset.y;
            float zAngles;
            if (moveVy == 0)
            {
                zAngles = moveVx >= 0 ? -90 : 90;
            }
            zAngles = Mathf.Atan(moveVx / moveVy) * (-180 / Mathf.PI);
            if (moveVy < 0)
            {
                zAngles = zAngles - 180;
            }
            //Debug.logger.Log("zAngles:  " + zAngles);
            Vector3 tempAngles = new Vector3(0, 0, zAngles);
            Quaternion tempQua = this.transform.rotation;
            tempQua.eulerAngles = tempAngles;
            this.transform.rotation = tempQua;
        }
    }
}
