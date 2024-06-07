﻿using Domain.ValueObjects;

namespace Domain.Entities
{
    public class PlayerScore(PlayerId playerId, MusicId musicId, DifficultyId difficultyId, PlayAt playAt, OptionId? optionIdLeft, OptionId? optionIdRight, Legacy legacy, AutoScratch autoScratch, PikaGreat pikaGreat, Great great, Bp bp, ComboBreak comboBreak, ClearLampId clearLampId, Memo memo)
    {
        public PlayerId PlayerId { get; private set; } = playerId;
        public MusicId MusicId { get; private set; } = musicId;
        public DifficultyId DifficultyId { get; private set; } = difficultyId;
        public PlayAt PlayAt { get; private set; } = playAt;
        public OptionId? OptionIdLeft { get; private set; } = optionIdLeft;
        public OptionId? OptionIdRight { get; private set; } = optionIdRight;
        public Legacy Legacy { get; private set; } = legacy;
        public AutoScratch AutoScratch { get; private set; } = autoScratch;
        public PikaGreat PikaGreat { get; private set; } = pikaGreat;
        public Great Great { get; private set; } = great;
        public Bp Bp { get; private set; } = bp;
        public ComboBreak ComboBreak { get; private set; } = comboBreak;
        public ClearLampId ClearLampId { get; private set; } = clearLampId;
        public Memo Memo { get; private set; } = memo;
    }

}