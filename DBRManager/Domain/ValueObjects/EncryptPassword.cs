﻿namespace Domain.ValueObjects
{
    public record EncryptPassword
    {
        public string Value { get; }

        public EncryptPassword(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("EncryptPassword cannot be null or empty.");
            Value = value;
        }
    }

}