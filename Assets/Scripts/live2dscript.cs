using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using live2d;

[ExecuteInEditMode]
public class live2dscript : MonoBehaviour {
	public TextAsset mocFile ;
	public Texture2D[] textureFiles ;
	private EyeBlinkMotion eyeBlink = new EyeBlinkMotion();//目ぱち
	private Live2DModelUnity live2DModel;
	private Matrix4x4 live2DCanvasPos;
	float mouth=0;//口パラメーター
	public float mouthspeed;//口速度
	float time=0;//口用タイマー
	public bool mouthcheck=false;//テキストを読み上げているかいないか
	void Start ()
	{
		//live2d初期化
		if (live2DModel != null) return;
		Live2D.init();

		//テクスチャー読み込み
		live2DModel = Live2DModelUnity.loadModel(mocFile.bytes);

		//テクスチャー読み込み
		for (int i = 0; i < textureFiles.Length; i++)
		{
			live2DModel.setTexture(i, textureFiles[i]);
		}

		//モデルの幅を獲得
		float modelWidth = live2DModel.getCanvasWidth();

		//canvas作成
		live2DCanvasPos = Matrix4x4.Ortho(0, modelWidth, modelWidth, 0, -50.0f, 50.0f);
	}

	void Update()
	{
		
		if (live2DModel == null) return;
		live2DModel.setMatrix(transform.localToWorldMatrix * live2DCanvasPos);

		if (!Application.isPlaying)
		{
			live2DModel.update();
			return;
		}



		double t = (UtSystem.getUserTimeMSec() / 1000.0) * 2 * Math.PI;

		/*
		//デバック用
		if (Input.GetMouseButtonUp (0)) {
			mouthcheck = !mouthcheck;
		}
		*/

		//テキストを読み上げているか判定
		if (mouthcheck) {
			mouth = (float)Mathf.PingPong (time+=mouthspeed, 1);//口動かす

		} else {
			//徐々に口を閉じる
			if (mouth > 0) {
				mouth -= 0.1f;
			}
		}

		live2DModel.setParamFloat("PARAM_MOUTH_OPEN_Y",mouth); //口


		live2DModel.setParamFloat("PARAM_BREATH", (float) (0.5f + 0.5f * Math.Sin( t/3.2345 )),1);//呼吸


		eyeBlink.setParam(live2DModel);//目ぱち
		　
		live2DModel.update();
	}

	void OnRenderObject()
	{
		if (live2DModel == null) return;
		live2DModel.draw();
	}
}
