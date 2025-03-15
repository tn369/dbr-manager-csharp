using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// ゲームモード、難易度、ノーツなどのさまざまなプロパティを持つ音楽譜面を表します
    /// </summary>
    public sealed class Chart
    {
        /// <summary>
        /// 音楽ID
        /// </summary>
        public MusicId MusicId { get; private set; }

        /// <summary>
        /// ゲームモード
        /// </summary>
        public GameMode GameMode { get; private set; }

        /// <summary>
        /// 難易度レベル
        /// </summary>
        public Difficulty Difficulty { get; private set; }

        /// <summary>
        /// レベル
        /// </summary>
        public Level Level { get; private set; }

        /// <summary>
        /// BPM（1分あたりのビート数）
        /// </summary>
        public Bpm Bpm { get; private set; }

        /// <summary>
        /// 総ノーツ数
        /// </summary>
        public Notes NotesTotal { get; private set; }

        /// <summary>
        /// スクラッチノーツ数
        /// </summary>
        public Notes NotesScratch { get; private set; }

        /// <summary>
        /// チャージノーツ数
        /// </summary>
        public Notes NotesCharge { get; private set; }

        /// <summary>
        /// バックスピンノーツ数
        /// </summary>
        public Notes NotesBackspin { get; private set; }

        /// <summary>
        /// <see cref="Chart"/> クラスの新しいインスタンスを初期化します
        /// </summary>
        /// <param name="musicId">音楽ID</param>
        /// <param name="gameMode">ゲームモード</param>
        /// <param name="difficulty">難易度レベル</param>
        /// <param name="level">レベル</param>
        /// <param name="bpm">BPM</param>
        /// <param name="notesTotal">総ノーツ数</param>
        /// <param name="notesScratch">スクラッチノーツ数</param>
        /// <param name="notesCharge">チャージノーツ数</param>
        /// <param name="notesBackspin">バックスピンノーツ数</param>
        /// <exception cref="ArgumentException">スクラッチ、チャージ、バックスピンノーツの合計が総ノーツ数を超える場合にスローされます</exception>
        public Chart(MusicId musicId, GameMode gameMode, Difficulty difficulty, Level level, Bpm bpm, Notes notesTotal, Notes notesScratch, Notes notesCharge, Notes notesBackspin)
        {
            ArgumentNullException.ThrowIfNull(musicId);
            ArgumentNullException.ThrowIfNull(gameMode);
            ArgumentNullException.ThrowIfNull(difficulty);
            ArgumentNullException.ThrowIfNull(level);
            ArgumentNullException.ThrowIfNull(bpm);
            ArgumentNullException.ThrowIfNull(notesTotal);
            ArgumentNullException.ThrowIfNull(notesScratch);
            ArgumentNullException.ThrowIfNull(notesCharge);
            ArgumentNullException.ThrowIfNull(notesBackspin);

            if (Notes.Sum(notesScratch, notesCharge, notesBackspin) > notesTotal)
            {
                throw new ArgumentException("NotesScratch, NotesCharge, and NotesBackspin total cannot exceed NotesTotal.");
            }

            MusicId = musicId;
            GameMode = gameMode;
            Difficulty = difficulty;
            Level = level;
            Bpm = bpm;
            NotesTotal = notesTotal;
            NotesScratch = notesScratch;
            NotesCharge = notesCharge;
            NotesBackspin = notesBackspin;
        }

        /// <summary>
        /// <see cref="Chart"/> クラスのデフォルトインスタンスの作成を防ぎます
        /// </summary>
        private Chart() { }

        /// <summary>
        /// 現在の譜面をバトル譜面に変換します
        /// </summary>
        /// <returns>バトル譜面を表す新しい <see cref="Chart"/> インスタンス</returns>
        /// <exception cref="ArgumentException">現在の譜面がシングル譜面でない場合にスローされます</exception>
        public Chart ToBattleChart()
        {
            if (!GameMode.IsSingle())
            {
                throw new ArgumentException("Battle chart can only be created from a single chart.");
            }

            return new Chart(
                MusicId,
                new GameMode(GameModeType.Battle),
                Difficulty,
                Level,
                Bpm,
                NotesTotal.BattleValue(),
                NotesScratch.BattleValue(),
                NotesCharge.BattleValue(),
                NotesBackspin.BattleValue()
            );
        }
    }
}