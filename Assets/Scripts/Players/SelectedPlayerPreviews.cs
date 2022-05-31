using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class SelectedPlayerPreviews : MonoBehaviour
    {
        private SelectedPlayerPreview[] fields;

        private SelectedPlayerPreview[] GetFields()
        {
            return fields ??= GetComponentsInChildren<SelectedPlayerPreview>();
        }

        public async UniTask<SelectedPlayerPreview> HandleField()
        {
            var clicks = GetFields().Select(field => field.HandleField());
            return (await UniTask.WhenAny(clicks)).result;
        }
    }
}