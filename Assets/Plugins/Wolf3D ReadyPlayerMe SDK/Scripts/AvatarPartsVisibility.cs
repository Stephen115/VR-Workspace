namespace Wolf3D.ReadyPlayerMe.AvatarSDK
{
    public struct AvatarPartsVisibility
    {
        // head parts
        public bool disableHair;
        public bool disableEyes;
        public bool disableTeeth;
        public bool disableBeard;
        public bool disableGlasses;
        public bool disableHeadwear;

        // half body parts
        public bool disableHalfbodyHands;
        public bool disableHalfbodyShirt;

        // full body parts
        public bool disableFullbodySkin;
        public bool disableFullbodyOutfitTop;
        public bool disableFullbodyOutfitBottom;
        public bool disableFullbodyOutfitFootwear;

        public void SetVisibility(Avatar avatar)
        {
            // set head parts' visibility
            avatar.HairMesh?.gameObject.SetActive(!disableHair);
            avatar.TeethMesh?.gameObject.SetActive(!disableTeeth);
            avatar.BeardMesh?.gameObject.SetActive(!disableBeard);
            avatar.LeftEyeMesh?.gameObject.SetActive(!disableEyes);
            avatar.RightEyeMesh?.gameObject.SetActive(!disableEyes);
            avatar.GlassesMesh?.gameObject.SetActive(!disableGlasses);
            avatar.HeadwearMesh?.gameObject.SetActive(!disableHeadwear);

            // set half body parts' visibility
            avatar.HalfbodyHandsMesh?.gameObject.SetActive(!disableHalfbodyHands);
            avatar.HalfbodyShirtMesh?.gameObject.SetActive(!disableHalfbodyShirt);

            // set full body parts' visibility
            avatar.FullbodySkin?.gameObject.SetActive(!disableFullbodySkin);
            avatar.FullbodyOutfitTop?.gameObject.SetActive(!disableFullbodyOutfitTop);
            avatar.FullbodyOutfitBottom?.gameObject.SetActive(!disableFullbodyOutfitBottom);
            avatar.FullbodyOutfitFootwear?.gameObject.SetActive(!disableFullbodyOutfitFootwear);
        }
    }
}